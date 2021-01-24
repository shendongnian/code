    public T GetItem<T>(string key, Func<T> loadItemFromDb)
    {
        object cachedItem = memoryCache.Get(key);
        if (cachedItem is T)
           return (T)cachedItem;
        T item = loadItemFromDb();
        memoryCache.Add(key, item);
        return item;
    }
        
