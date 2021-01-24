        public static T AddOrGetExisting<T>(ObjectCache cache, string key, Func<(T item, CacheItemPolicy policy)> addFunc)
        {
            object cachedItem = cache.Get(key);
            if (cachedItem is T t)
                return t;
            (T item, CacheItemPolicy policy) = addFunc();
            cache.Add(key, item, policy);
            return item;
        }
