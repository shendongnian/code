    public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
    {
        var cache = new ConcurrentDictionary<A, R>();
        return a => cache.GetOrAdd(a, f);
    };
