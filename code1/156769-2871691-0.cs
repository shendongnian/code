    internal object DoInsert(bool isPublic, string key, object value, CacheDependency dependencies, DateTime utcAbsoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback, bool replace)
    {
        using (dependencies)
        {
            object obj2;
            CacheEntry cacheKey = new CacheEntry(key, value, dependencies, onRemoveCallback, utcAbsoluteExpiration, slidingExpiration, priority, isPublic);
            cacheKey = this.UpdateCache(cacheKey, cacheKey, replace, CacheItemRemovedReason.Removed, out obj2);
            if (cacheKey != null)
            {
                return cacheKey.Value;
            }
            return null;
        }
    }
