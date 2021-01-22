    static void Main()
    {
    	using (SingleInstanceMutex sim = new SingleInstanceMutex())
    	{
    		if (sim.IsOtherInstanceRunning)
    		{
    			Application.Exit();
    		}
    
    		// Initialize program here.
    	}
    }
