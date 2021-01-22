    public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
    {
        var cache = new SynchronizedConcurrentDictionary<A, R>();
    
        return key => cache.GetOrAdd(key, f);
    }
