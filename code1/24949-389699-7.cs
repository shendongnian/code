    public void Insert(
        string key,
        Object value,
        CacheDependency dependencies,
        DateTime absoluteExpiration,
        TimeSpan slidingExpiration,
        CacheItemUpdateCallback onUpdateCallback
    )
