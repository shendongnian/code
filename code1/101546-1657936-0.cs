    ConcurrentDictionary<T,K> cache = ...;
    Parallel.ForEach(items, (item, loopState) =>
    {
        K value;
        if (!cache.TryGetValue(item.Key, out value))
        {
            value = SomeIntensiveOperation();
            cache.TryAdd(item.Key, value);
        }
        // Do something with value
    } );
