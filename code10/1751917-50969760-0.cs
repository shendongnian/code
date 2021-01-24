    public class CacheService : ICacheService
    {
        public T Get<T>(string cacheId, Func<T> getItemCallback) where T : class
        {
            var cacheExpiry = DateTime.UtcNow.AddMinutes(120);
    
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpRuntime.Cache.Insert(cacheId, item, null, cacheExpiry, Cache.NoSlidingExpiration);
            }
            return item;
        }
    
        protected virtual InsertCache(string key, Object value, CacheDependency dependencies, 
                               DateTime absoluteExpiration, TimeSpan slidingExpiration) {
            HttpRuntime.Cache.Insert(key, value, dependencies, absoluteExpiration, 
                         Cache.slidingExpiration);
        }
    }
