    public object Remove(string key)
    {
        CacheKey cacheKey = new CacheKey(key, true);
        return this._cacheInternal.DoRemove(cacheKey, CacheItemRemovedReason.Removed);
    }
