    private readonly ObjectCache _cache = MemoryCache.Default;
    public T GetToken()
    {
        if (!_cache.Contains("token"))
        {
            GetAndCacheNewToken();
        }
        return _cache.Get("token") as T;
    }
    public void GetAndCacheNewToken()
    {
        T token;
    
        // Get your token.
        _cache.Add(
            "token", 
            token, 
            new CacheItemPolicy() {AbsoluteExpiration = token.ValidTo.AddSeconds(-1)});
    }
