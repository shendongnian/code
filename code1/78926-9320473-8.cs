    public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
    {
        var cache = new ConcurrentDictionary<A, R>();
        var syncMap = new ConcurrentDictionary<A, object>();
        return a =>
        {
            R r;
            if (!cache.TryGetValue(a, out r))
            {
                var sync = syncMap.GetOrAdd(a, new object());
                lock (sync)
                {
                    r = cache.GetOrAdd(a, f);
                }
                syncMap.TryRemove(a, out sync);
            }
            return r;
        };
    }
