    using System.Runtime.Caching;
    MemoryCache cache;
    object cachedObject;
    object webServiceResult;
    cache = new MemoryCache("StackOverflow");
    cachedObject = cache.Get("MyCacheItem");
    if (cachedObject == null)
    {
        // Call the web service
        webServiceResult = new Object();
        cache.Add("MyCacheItem", webServiceResult, DateTime.Now.AddMinutes(5));
    }
    else
    {
        webServiceResult = (object)cachedObject;
    }
