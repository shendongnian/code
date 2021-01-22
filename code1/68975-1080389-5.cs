	public void Populate(bool reload)
	{
	    while (this.DataWorker.IsBusy) {
	    	Thread.Sleep(100);
	    }
	    
	    // Disable the filter options
	    IvdSession.Instance.FilterManager.SetEnabledState(this.GetType(), false);
	
	    // Perform the population
	    this.DataWorker.RunWorkerAsync(reload);
	}
