	    public void Dispose ()
	    {
	        // Dispose logic here ...
	
	        // It's a bad error if someone forgets to call Dispose,
	        // so in Debug builds, we put a finalizer in to detect
	        // the error. If Dispose is called, we suppress the
	        // finalizer.
	#if DEBUG
	        GC.SuppressFinalize(this);
	#endif
	    }
	
	#if DEBUG
	    ~TimedLock()
	    {
	        // If this finalizer runs, someone somewhere failed to
	        // call Dispose, which means we've failed to leave
	        // a monitor!
	        System.Diagnostics.Debug.Fail("Undisposed lock");
	    }
	#endif
