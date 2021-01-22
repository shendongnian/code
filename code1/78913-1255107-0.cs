    public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
    {
      var map = new ConcurrentDictionary<A, Lazy<R>>();
      return a =>
        {
          Lazy<R> lazy = new Lazy<R>(() => f(a), LazyExecutionMode.EnsureSingleThreadSafeExecution);
          if(!map.TryAdd(a, lazy))
          {
            return map[a].Value;
          }
          return lazy.Value;
        };
    }
