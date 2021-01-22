    public static class SharedResourceManager
    {
    	private static readonly object syncLock = new object();
    
    	private static SharedResource res { get; set; }
    
    	public static SharedResource Resource
    	{
    		get
    		{
    			lock (syncLock)
    				return res;
    		}
    		set
    		{
    			lock(syncLock)
    				res = value;
    		}
    	}
    }
