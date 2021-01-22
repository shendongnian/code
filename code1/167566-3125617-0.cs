            private bool CheckForDuplicatesInCache(Message theMessage)
        {
            var cacheClient = MemcachedClient.GetInstance("IntegrationCache");
            var cacheClient2 = MemcachedClient.GetInstance("IntegrationCache2");
            var messageHash = theMessage.GetHashCode();
            if (cacheClient.Get(messageHash.ToString()).IsNotNull())
            {
                IntegrationContext.WriteLog("Warning: This message is a duplicate. Will Not Process.");
                return false;
            }
            if (cacheClient2.Get(messageHash.ToString()).IsNotNull())
            {
                IntegrationContext.WriteLog("Warning: This message is a duplicate. Will Not Process.");
                return false;
            }
            cacheClient.Set(messageHash.ToString(), "nothing", new TimeSpan(2, 0, 0));
            cacheClient2.Set(messageHash.ToString(), "nothing", new TimeSpan(2, 0, 0));
            return true;
        }
