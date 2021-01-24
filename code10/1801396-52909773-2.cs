    if (IsDisposed)
    {
    	if (collection != null)
    	{
    		foreach (ChangeMonitor item in collection)
    		{
    			item?.Dispose();
    		}
    	}
    }
    else
    {
    	MemoryCacheKey memoryCacheKey = new MemoryCacheKey(key);
    	MemoryCacheStore store = GetStore(memoryCacheKey);
    	store.Set(memoryCacheKey, new MemoryCacheEntry(key, value, absExp, slidingExp, priority, collection, removedCallback, this));
    }
