    T GetT(string key)
    {
        T item = (cache.Get(key) as T);
        if (item == null)
        {
            lock (yourSyncRoot)
            {
                // double check it here
                item = (cache.Get(key) as T);
                if (item != null)
                    return item;
                item = GetMyItemFromMyPersistentStore(key); // db?
                if (item == null)
                    return null;
                string[] dependencyKeys = {your, dependency, keys};
                cache.Insert(key, item, new CacheDependency(null, dependencyKeys), 
                             absoluteExpiration, slidingExpiration, priority, null);
            }
        }
        return item;
    }
