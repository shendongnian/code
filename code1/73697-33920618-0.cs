    public static class FuncHelpers
    {
       /// <summary>
       /// Returns a same function wrapped into cache-mechanism
       /// </summary>
       public static Func<TIn, TRes> Cached<TIn, TRes>(this Func<TIn, TRes> func, 
          Func<TIn,string> keySelector, 
          Func<TIn,CacheItemPolicy> policy)
        {
            var cache = new MemoryCache(Guid.NewGuid().ToString());
            
            Func<TIn, TRes> f = (item) =>
            {
                var key = keySelector(item);
                var newItem = new Lazy<TRes>(() => func(item));
                var oldItem = cache.AddOrGetExisting(key,newItem , policy(item)) as Lazy<TRes>;
                try
                {
                    return (oldItem ?? newItem).Value;
                }
                catch
                {
                    // Handle cached lazy exception by evicting from cache.
                    cache.Remove(key);
                    throw;
                }
                
            };
            return f;
        }
       //simplified version
       public static Func<TIn, TRes> Cached<TIn, TRes>(this Func<TIn, TRes> func, Func<TIn, string> keySelector,
            TimeSpan duration)
        {
            if (duration.Ticks<=0) return func;
            return Cached(func, keySelector,
              item => new CacheItemPolicy() {AbsoluteExpiration = DateTimeOffset.Now + duration});
        }
    }
