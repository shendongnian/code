    public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
    {
        var cache = new ConcurrentDictionary<A, Lazy<R>>();
        return a => cache.GetOrAdd(a, new Lazy<R>(() => f(a))).Value;
    }
