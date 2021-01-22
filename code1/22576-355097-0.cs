    class Fish3 : IDisposable
    {
    	Thread t;
    	private ManualResetEvent terminate = new ManualResetEvent(false);
    	private volatile int disposed = 0;
    
    	public Fish3()
    	{
    		t = new Thread(new ThreadStart(BackgroundWork));
    		t.IsBackground = true;
    		t.Start();
    	}
    
    	public void BackgroundWork()
    	{
    		while(!terminate.WaitOne(1000, false))
    		{
    			Swim();			
    		}
    	}
    
    	public void Swim()
    	{
    		Console.WriteLine("The third fish is Swimming");
    	}
    
    	public void Dispose()
    	{
    		if(Interlocked.Exchange(ref disposed, 1) == 0)
    		{
    			terminate.Set();
    			t.Join();
    			GC.SuppressFinalize(this);
    		}
    	}
    
    	~Fish3()
    	{
    		if(Interlocked.Exchange(ref disposed, 1) == 0)
    		{
    			Dispose();
    		}
    	}
    }
