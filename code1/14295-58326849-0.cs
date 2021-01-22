    static MutexGlobal _globalMutex = null;
    static MutexGlobal GlobalMutexAccessEMTP
    {
    	get
    	{
    		if (_globalMutex == null)
    		{
    			_globalMutex = new MutexGlobal();
    		}
    		return _globalMutex;
    	}
    }
    
    using (GlobalMutexAccessEMTP.GetAwaiter())
    {
        ...
    }	
				
