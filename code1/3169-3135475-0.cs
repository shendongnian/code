    private T GetOrAddToCache<T>(string cacheKey, GenericObjectParamsDelegate<T> creator, params object[] creatorArgs) where T : class, new()
        {
            T returnValue = HttpContext.Current.Cache[cacheKey] as T;
            if (returnValue == null)
            {
                lock (this)
                {
                    returnValue = HttpContext.Current.Cache[cacheKey] as T;
                    if (returnValue == null)
                    {
                        returnValue = creator(creatorArgs);
                        if (returnValue == null)
                        {
                            throw new Exception("Attempt to cache a null reference");
                        }
                        HttpContext.Current.Cache.Add(
                            cacheKey,
                            returnValue,
                            null,
                            System.Web.Caching.Cache.NoAbsoluteExpiration,
                            System.Web.Caching.Cache.NoSlidingExpiration,
                            CacheItemPriority.Normal,
                            null);
                    }
                }
            }
            return returnValue;
        }
