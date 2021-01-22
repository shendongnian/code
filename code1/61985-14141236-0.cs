    public class CacheItemWrapper
    {
        public string Value { get; set; }
    }
...
    cache.Insert(cacheKey, new CacheItemWrapper { Value = null }, ...);
