﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectExtensions.Azure.ServiceBus.Interfaces;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Practices.TransientFaultHandling;

namespace ProjectExtensions.Azure.ServiceBus.Wrappers {
    
    class SubscriptionClientWrapper : ISubscriptionClient {

        SubscriptionClient client;

        public SubscriptionClientWrapper(SubscriptionClient client) {
            Guard.ArgumentNotNull(client, "client");
            this.client = client;
        }

        public ReceiveMode Mode {
            get {
                return client.Mode;
            }
        }

        public int PrefetchCount {
            get {
                return client.PrefetchCount;
            }
            set {
                client.PrefetchCount = value;
            }
        }

        public IAsyncResult BeginReceive(TimeSpan serverWaitTime, AsyncCallback callback, object state) {
            return client.BeginReceive(serverWaitTime, callback, state);
        }

        public BrokeredMessage EndReceive(IAsyncResult result) {
            return client.EndReceive(result);
        }

        public void Close() {
            client.Close();
        }
    }
}
