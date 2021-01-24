    var CachingPolicy = new CacheItemPolicy();
    var Cache = new MemoryCache("YourCacheName");
    container.RegisterInstance(CachingPolicy);
    container.RegisterInstance(Cache);
    
    container.Dispose(); //disposes cache as well. But calling methods on cache object won't throw exception.
    
    //at this point, you should create the cache again, like
    CachingPolicy = new CacheItemPolicy();
    Cache = new MemoryCache("YourCacheName");
    container.RegisterInstance(CachingPolicy);
    container.RegisterInstance(Cache);
