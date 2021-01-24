    private static MemoryCache cache;
        static readonly object cacheLock = new object();
        private int expiry_timeout = 5;
        public bool TextInputRecently(string text)
        {
            //Returns null if the string does not exist, prevents a race condition where the cache invalidates between the contains check and the retrieval.
            var cachedString = MemoryCache.Default.Get(text, null) as string;
            if (cachedString != null)
                return true;
            lock (cacheLock)
            {
                //Check to see if anyone wrote to the cache while we where waiting our turn to write the new value.
                cachedString = MemoryCache.Default.Get(text, null) as string;
                if (cachedString != null)
                    return true;
                //The value still did not exist so we now write it in to the cache.                
                CacheItemPolicy cip = new CacheItemPolicy()
                {
                    AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddSeconds(expiry_timeout))
                };
                MemoryCache.Default.Set(text, "", cip);
                return false;
            }
        }        
