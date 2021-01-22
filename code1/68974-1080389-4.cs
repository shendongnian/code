	public void Populate(bool reload)
	{
	    
	    lock (lockThis)
	    {
	        // Disable the filter options
	        IvdSession.Instance.FilterManager.SetEnabledState(this.GetType(), false);
	
	        // do actual work.
	    }
	
	}
