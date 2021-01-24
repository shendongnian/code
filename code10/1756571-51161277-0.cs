    public T GetOrSetCache<T>
    	(string key,T obj,int cacheTime) where T:class,new()
    {
    	System.Web.Caching.Cache cacheContainer = HttpRuntime.Cache;
    	T cacheObj = cacheContainer.Get(key) as T;
    
    	if (cacheObj == null)
    	{
    		cacheContainer.Insert(key, 
    			obj, 
    			null, 
    			DateTime.MaxValue, 
    			DateTime.Now.AddMinutes(cacheTime).TimeOfDay);
    		cacheObj = obj;
    	}
    
    	return cacheObj;
    }
