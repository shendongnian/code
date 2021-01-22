    public static bool PerformLockedProcess(Action process, string commonLockName, TimeSpan timeout)
    {
    	Mutex mutex = null;
    
    	// Get the Mutex for the User
    	try
    	{
    		bool created;
    		var security = new MutexSecurity();
    		security.AddAccessRule(new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.Synchronize | MutexRights.Modify, AccessControlType.Allow));
    
    		mutex = new Mutex(false, commonLockName, out created, security);
    
    		bool acquired = mutex.WaitOne(timeout);
    
    		if (acquired)
    		{
    			process();
    
    			return true;
    		}
    
    		return false;
    	}
    	finally
    	{
    		// Make sure we do not abandon the Mutex
    		if (mutex != null)
    		{
    			try
    			{
    				mutex.ReleaseMutex();
    			}
    			catch (ApplicationException)
    			{
    				// In case that failes
    			}
    		}
    	}
    }
