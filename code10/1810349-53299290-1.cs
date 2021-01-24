    namespace System
    {
        public static class MemoizerExtension
        {
            internal static ConditionalWeakTable<object, ConcurrentDictionary<string, object>> _weakCache =
                new ConditionalWeakTable<object, ConcurrentDictionary<string, object>>();
    
            public static TResult Memoized<T1, TResult>(
                this object context,
                T1 arg,
                Func<T1, TResult> f,
                [CallerMemberName] string cacheKey = null)
            {
                if (context == null) throw new ArgumentNullException(nameof(context));
                if (cacheKey == null) throw new ArgumentNullException(nameof(cacheKey));
    
                var objCache = _weakCache.GetOrCreateValue(context);
    
                var methodCache = (ConcurrentDictionary<T1, TResult>) objCache
                    .GetOrAdd(cacheKey, _ => new ConcurrentDictionary<T1, TResult>());
    
                return methodCache.GetOrAdd(arg, f);
            }
        }
    }
