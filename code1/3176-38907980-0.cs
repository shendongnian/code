    using System;
    using System.Collections.Concurrent;
    using System.Web;
    using System.Web.Caching;
    public static class CacheExtensions
    {
        private static ConcurrentDictionary<string, object> keyLocks = new ConcurrentDictionary<string, object>();
        /// <summary>
        /// Get or Add the item to the cache
        /// </summary>
        public static T GetOrAdd<T>(this Cache cache, string key, Func<T> factory, int durationInSeconds, bool synchronised = true)
            where T : class
        {
            // Try and get value from the cache
            var value = cache.Get(key);
            if (value == null)
            {
                // If not yet cached, lock the key value and add to cache 
                lock (keyLocks.GetOrAdd(key, new object()))
                {
                    // Try and get from cache again in case it has been added in the meantime
                    value = HttpRuntime.Cache.Get(key);
                    if (value == null && (value = factory()) != null)
                    {
                        HttpRuntime.Cache.Insert(key,
                            value,
                            null,
                            DateTime.Now.AddSeconds(durationInSeconds),
                            Cache.NoSlidingExpiration,
                            CacheItemPriority.Default,
                            null);
                    }
                    // Remove temporary key lock
                    object locker;
                    keyLocks.TryRemove(key, out locker);
                }
            }
            return value as T;
        }
    }
