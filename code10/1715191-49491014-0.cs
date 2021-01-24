    ObjectCache cache = MemoryCache.Default;
    var cacheObject = cache.Get(cacheKey);
    if (cacheObject == null)
    {
        cacheObject = //do something to get it
        CacheItemPolicy policy = new CacheItemPolicy();
        policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2);
        cache.Add(cacheKey, cacheObject, policy);
    }
    return cacheObject;
