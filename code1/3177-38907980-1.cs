    using System;
    using System.Collections.Concurrent;
    using System.Web.Caching;
    public static class CacheExtensions
    {
        private static ConcurrentDictionary<string, object> keyLocks = new ConcurrentDictionary<string, object>();
        /// <summary>
        /// Get or Add the item to the cache using the given key. Lazily executes the value factory only if/when needed
        /// </summary>
        public static T GetOrAdd<T>(this Cache cache, string key, int durationInSeconds, Func<T> factory)
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
                    value = cache.Get(key);
                    if (value == null && (value = factory()) != null)
                    {
                        // TODO: Some of these parameters could be added to method signature later if required
                        cache.Insert(
                            key: key,
                            value: value,
                            dependencies: null,
                            absoluteExpiration: DateTime.Now.AddSeconds(durationInSeconds),
                            slidingExpiration: Cache.NoSlidingExpiration,
                            priority: CacheItemPriority.Default,
                            onRemoveCallback: null);
                    }
                    // Remove temporary key lock
                    keyLocks.TryRemove(key, out object locker);
                }
            }
            return value as T;
        }
    }
