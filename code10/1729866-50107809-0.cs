    private static readonly _cacheLock = new object();
    private static readonly FileCache _cache = new FileCache($"{AppDomain.CurrentDomain.BaseDirectory}{"\\cache"}", false, TimeSpan.FromSeconds(30));
    /// ...
    lock (_cacheLock) {
        var myString = _cache.Get($"CacheKey{Id}");
        if (myString == null) {
            myString = generateString(Id);
            _cache.Set($"CacheKey{Id}", myString, new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30) });
        }
    }
