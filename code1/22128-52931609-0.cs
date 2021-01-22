    private DateTime GetCacheUtcExpiryDateTime(string cacheKey)
    {
        var aspnetcachestoreprovider = System.Web.HttpRuntime.Cache.GetType().GetProperty("InternalCache", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(System.Web.HttpRuntime.Cache, null);
        var intenralcachestore = aspnetcachestoreprovider.GetType().GetField("_cacheInternal", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(aspnetcachestoreprovider);
        Type TEnumCacheGetOptions = System.Web.HttpRuntime.Cache.GetType().Assembly.GetTypes().Where(d => d.Name == "CacheGetOptions").FirstOrDefault();
        object cacheEntry = intenralcachestore.GetType().GetMethod("DoGet", BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any, new[] { typeof(bool), typeof(string), TEnumCacheGetOptions }, null).Invoke(intenralcachestore, new Object[] { true, cacheKey, 1 }); ;
        PropertyInfo utcExpiresProperty = cacheEntry.GetType().GetProperty("UtcExpires", BindingFlags.NonPublic | BindingFlags.Instance);
        DateTime utcExpiresValue = (DateTime)utcExpiresProperty.GetValue(cacheEntry, null);
        return utcExpiresValue;
    }
