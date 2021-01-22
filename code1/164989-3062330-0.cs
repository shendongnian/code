    public static class CacheExtensions
    {
        public static void Remove<T>(this Cache cache)
        {
            cache.Remove(typeof(T).Name);
        }
        public static void AddToCache<T>(this Cache cache, object item)
        {
            cache.Add(typeof(T).Name,
                    item,
                    null,
                    DateTime.Now.AddMinutes(5),
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    System.Web.Caching.CacheItemPriority.Normal,
                    null);
        }
        public static bool TryGetItemFromCache<T>(this Cache cache, out T item) where T : class
        {
             item = cache.Get(typeof(T).Name) as T;
             return item != null;
        }
    }
