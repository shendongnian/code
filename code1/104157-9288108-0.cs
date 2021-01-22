    // from linqpad
    
    void Main()
    {
    	var td = new ThreadDangerous();
    	
    	// no problems using single thread (run this for as long as you want)
    	foreach (var x in Until(TimeSpan.FromSeconds(1)))
    		td.DoSomething();
    		
    	// thread dangerous - it won't take long at all for this to blow up
    	Parallel.ForEach(WhileTrue(), x => 
    		td.DoSomething());
    }
    
    class ThreadDangerous
    {
    	private Guid test;
    	private readonly Guid ctrl;
    	
    	public ThreadDangerous()
    	{
    		test = ctrl = Guid.NewGuid();
    	}
    	
    	public void DoSomething()
    	{			
    		test = Guid.NewGuid();
    		test = ctrl;		
    		
    		if (test != ctrl)
    			throw new Exception("This method is not thread safe");
    	}
    }
    
    IEnumerable<ulong> Until(TimeSpan duration)
    {
    	var until = DateTime.Now.Add(duration);
    	ulong i = 0;
    	while (DateTime.Now < until)
    	{
    		yield return i++;
    	}
    }
    
    IEnumerable<ulong> WhileTrue()
    {
    	ulong i = 0;
    	while (true)
    	{
    		yield return i++;
    	}
    }
