    private List<Guid> _objectExpirations;
    private void OnExpirationFired( object sender, DatabaseExpirationEventArgs e )
    {
    	_objectExpirations = e.ExpiredKeys;
    	lock(_objectExpirations)
    	{
    		foreach( Guid key in _objectExpirations)
    			this.RealCache.Remove(key);
    	}
    }
    
    private Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager _realCache;
    private Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager RealCache
    {
    	get
    	{
			lock(_syncRoot)    
			{		
    			if ( _realCache == null )
    				_realCache = Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager.CacheFactory.GetCacheManager();
    
    			return _realCache;
    		}
    	}
    }
    
    
    public object this[string key]
    {
    	get
    	{
    		lock(_objectExpirations)
    		{
    			if (_objectExpirations.Contains(key))
    				return null;
    			return this.RealCache.GetData(key);
    		}
    	}
    }
