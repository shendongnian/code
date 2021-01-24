    public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> f)
    {
        var cache = new ConcurrentDictionary<T, TResult>();
        return a => cache.GetOrAdd(a, f);
    }
    
    Measure(() => slowSquare(2));   // 00:00:00.1009680
    Measure(() => slowSquare(2));   // 00:00:00.1006473
    Measure(() => slowSquare(2));   // 00:00:00.1006373
    var memoizedSlow = slowSquare.Memoize();
    Measure(() => memoizedSlow(2)); // 00:00:00.1070149
    Measure(() => memoizedSlow(2)); // 00:00:00.0005227
    Measure(() => memoizedSlow(2)); // 00:00:00.0004159
