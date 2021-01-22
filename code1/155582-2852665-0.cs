     public Assembly GetAssembly()
        {
            Assembly result = cache.Get(assemblyKey) as Assembly;
            
            if (result == null)
            {
                lock (this)
                {
                    result = cache.Get(assemblyKey) as Assembly;
                    if (result == null)
                    {
                        assemblyName = System.Reflection.AssemblyName.GetAssemblyName(assemblyFile);
                        result = Assembly.Load(assemblyName);
                        cache.Add(assemblyKey, result, new CacheDependency(assemblyFile), Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.High, new CacheItemRemovedCallback(OnAssemblyRemoved));
                    }
                }
            }
            return result;
        }
