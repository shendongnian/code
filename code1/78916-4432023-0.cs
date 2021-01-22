        public static Func<TInput, TResult> Memoize<TInput, TResult>(
            this Func<TInput, TResult> func, IEqualityComparer<TInput> comparer = null)
        {
            var map = comparer == null
                          ? new ConcurrentDictionary<TInput, Lazy<TResult>>()
                          : new ConcurrentDictionary<TInput, Lazy<TResult>>(comparer);
            return input =>
                   {
                       var lazy = new Lazy<TResult>(() => func(input), LazyThreadSafetyMode.ExecutionAndPublication);
                       return map.TryAdd(input, lazy)
                                  ? lazy.Value
                                  : map[input].Value;
                   };
        }
