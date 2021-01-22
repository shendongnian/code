    <!-- language: c# -->
    public enum State
    {
    	Idle = 0,
    	Processing = 1,
    	Stop = 100,
    }
    public void Run()
    {
    	State state = State.Idle;	// could be a member variable, so a service could stop this too
    
    	double intervalInSeconds = 60;
    	System.DateTime nextExecution = System.DateTime.Now.AddSeconds(intervalInSeconds);
    	while (state != State.Stop)
    	{
    		switch (state)
    		{
    			case State.Idle:
    				{
    					if (nextExecution > System.DateTime.Now)
    					{
    						state = State.Processing;
    					}
    				}
    				break;
    			case State.Processing:
    				{
    					// do your once-per-minute code here
    
    					// if you want it to stop, just set it state to stop.
    					// if this was a service, you could stop execution by setting state to stop, also
    					// only time it would not stop is if it was waiting for the process to finish, which you can handle in other ways
    
    					state = State.Idle;
    					nextExecution = System.DateTime.Now.AddSeconds(intervalInSeconds);
    				}
    				break;
    			default:
    				break;
    		}
    
    		System.Threading.Thread.Sleep(1);
    	}
    }
