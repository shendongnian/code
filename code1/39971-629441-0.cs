    protected int RegisterCachedData(string id) {
       CacheItemRemovedCallback onCacheRemove;
       onCacheRemove = new CacheItemRemovedCallback(CheckCallback);
       Cache.Insert("AverageData", FindData(1), null, DateTime.Now.AddMinutes(20), TimeSpan.Zero, 1, onCacheRemove);
    }
    void CheckCallback(string str, object obj, CacheItemRemovedReason reason) {
       RegisterCachedData("0");
    }
    protected int FindCached() {
       if (Cache.Get("AverageData") == null) RegisterCachedData("0");
       return Cache.Get("AverageData");
    }
