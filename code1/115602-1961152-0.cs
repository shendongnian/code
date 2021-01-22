    public static void AddToCache(string key, Object value, int slidingMinutesToExpire)
    {
            if (slidingMinutesToExpire == 0)
            {
                HttpRuntime.Cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            }
            else
            {
                HttpRuntime.Cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(slidingMinutesToExpire), System.Web.Caching.CacheItemPriority.NotRemovable, null);
            }
        }
