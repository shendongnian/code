    private DateTime GetCacheUtcExpiryDateTime(string cacheKey)
    {
        MethodInfo GetCacheEntryMethod = null;
        Object CacheStore = null;
        bool GetterFound = true;
        GetCacheEntryMethod = System.Web.HttpRuntime.Cache.GetType().GetMethod("Get", BindingFlags.Instance | BindingFlags.NonPublic);
        if (GetCacheEntryMethod != null)
        {
            GetterFound = true;
            CacheStore = System.Web.HttpRuntime.Cache;
        }
        else
        {
            var aspnetcachestoreprovider = System.Web.HttpRuntime.Cache.GetType().GetProperty("InternalCache", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(System.Web.HttpRuntime.Cache, null);
            var intenralcachestore = aspnetcachestoreprovider.GetType().GetField("_cacheInternal", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(aspnetcachestoreprovider);
            Type TEnumCacheGetOptions = System.Web.HttpRuntime.Cache.GetType().Assembly.GetTypes().Where(d => d.Name == "CacheGetOptions").FirstOrDefault();
            GetCacheEntryMethod = intenralcachestore.GetType().GetMethod("DoGet", BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any, new[] { typeof(bool), typeof(string), TEnumCacheGetOptions }, null);
            GetterFound = false;
            CacheStore = intenralcachestore;
        }
        dynamic cacheEntry;
        if (GetterFound)
            cacheEntry = GetCacheEntryMethod.Invoke(CacheStore, new Object[] { cacheKey, 1 });
        else
            cacheEntry = GetCacheEntryMethod.Invoke(CacheStore, new Object[] { true, cacheKey, 1 });
        PropertyInfo utcExpiresProperty = cacheEntry.GetType().GetProperty("UtcExpires", BindingFlags.NonPublic | BindingFlags.Instance);
        DateTime utcExpiresValue = (DateTime)utcExpiresProperty.GetValue(cacheEntry, null);
        return utcExpiresValue;
    }
