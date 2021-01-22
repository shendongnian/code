    public interface ICacheable
    {
    }
    public static void UpdateCacheEntryItem(CacheKey cacheKey, int id)
    {
        //look up the cacheEntry in cache which is a dictionary.
        Dictionary<CacheKey,ICacheable> cacheEntry = CacheRef[cacheKey.ToString()];
        //call the corresponding method which knows how to hydrate that item and pass in the id.
        cacheEntry[id] = (ICacheable)HydrateCacheEntryItemMethods[cacheKey].Invoke(id);
    }
