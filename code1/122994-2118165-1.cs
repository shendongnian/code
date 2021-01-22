    public Dictionary<string, int> CommentCounts {
        get {
            const string cacheKey = "CommentCounts";
            HttpContext c = HttpContext.Current;
    
            if (c.Cache[cacheKey] == null) CommentCounts = new Dictionary<string, int>();
            return (Dictionary<string, int>)c.Cache[cacheKey];
        }
        set {
            const string cacheKey = "CommentCounts";
            c.Cache.Insert(cacheKey, value, null, DateTime.UtcNow.AddSeconds(30), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            c.Trace.Warn("New cached item: " + cacheKey); 
        }
    }
