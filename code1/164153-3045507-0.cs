    using System.Web;
    using System.Web.Caching;
    Cache webCache;
    webCache = HttpContext.Current.Cache;
    // See if there's a cached item already
    cachedObject = webCache.Get("MyCacheItem");
    if (cachedObject == null)
    {
        // If there's nothing in the cache, call the web service to get a new item
        webServiceResult = new Object();
        // Cache the web service result for five minutes
        webCache.Add("MyCacheItem", webServiceResult, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
    }
    else
    {
        // Item already in the cache - cast it to the right type
        webServiceResult = (object)cachedObject;
    }
