        IUnityContainer container= HttpRuntime.Cache.Get("Unity") as IUnityContainer;
        if (container == null)
        {
            container= // init container
            HttpRuntime.Cache.Add("Unity",
                container,
                null,
                Cache.NoAbsoluteExpiration,
                Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable,
                null);
        }
        // return container or something
