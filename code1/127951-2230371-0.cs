    UserBlogSettings cacheItem = HttpRuntime.Cache[cacheKey] as UserBlogSettings;
    if (cacheItem == null)
    {
        cacheItem = new UserBlogSettings();
        HttpRuntime.Cache.Insert(cacheKey, cacheItem, null, 
                             DateTime.Now.AddMinutes(1),
                             Cache.NoSlidingExpiration);
    }
    return cacheItem;
