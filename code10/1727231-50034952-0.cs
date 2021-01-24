    public static class WebCache
    {
    	#region Private Fields
    
    	private static readonly MemoryCache _cache = MemoryCache.Default;
    
    	private static readonly HashSet<string> _keysList = new HashSet<string>();
    
    	private static readonly object _lock = new object();
    
    	#endregion Private Fields
    
    	#region Public Methods
    
    	public static T GetUpdate<T>(string key, Func<T> getValue)
    	{
    		if (_cache[key] == null) { Update(key, getValue); }
    
    		return (T)_cache[key];
    	}
    
    	public static void Remove(string key)
    	{
    		lock (_lock)
    		{
    			_cache.Remove(key);
    			_keysList.Remove(key);
    		}
    	}
    
    	public static void RemoveAll()
    	{
    		string[] keyArray = new string[_keysList.Count];
    		_keysList.CopyTo(keyArray);
    		foreach (string key in keyArray) { lock (_lock) { _cache.Remove(key); } }
    		lock (_lock) { _keysList.Clear(); }
    		keyArray.ExClear();
    	}
    
    	public static void Update<T>(string key, Func<T> getValue)
    	{
    		CacheItemPolicy policy = new CacheItemPolicy
    		{
    			AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration,
    			SlidingExpiration = new TimeSpan(2, 0, 0),
    			RemovedCallback =
    				(arg) => { lock (_lock) { _keysList.Remove(arg.CacheItem.Key); } },
    			Priority = CacheItemPriority.Default
    		};
    
    		Remove(key);
    
    		lock (_lock) { _cache.Add(key, getValue(), policy); _keysList.Add(key); }
    	}
    
    	#endregion Public Methods
    }
