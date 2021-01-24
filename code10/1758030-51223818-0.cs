    public class CacheWrapper
    {
        private static ObjectCache cache = null;
    
        public static ObjectCache Cache
        {
            get
            {
                if (cache == null)
                {
                    cache = MemoryCache.Default;
                }
                return cache;
            }
        }
    
        public static void Add(string key, object data, double expireInMinute)
        {
            Delete(key);
            Cache.Add(key, data, DateTime.Now.AddMinutes(expireInMinute));
        }
    
        public static object Get(string key)
        {
            if (!Cache.Contains(key))
                return null;
            return Cache[key];
        }
    
        public static void Delete(string key)
        {
            if (Cache.Contains(key))
            {
                Cache.Remove(key);
            }
        }
    }
