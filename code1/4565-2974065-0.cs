    public static ManualResetEvent evtToWait = new ManualResetEvent(false);
    
    private static void ReadDataFromConsole( object state )
    {
    	Console.WriteLine("Enter \"x\" to exit or wait for 5 seconds.");
    
    	while (Console.ReadKey().KeyChar != 'x')
    	{
    		Console.Out.WriteLine("");
    		Console.Out.WriteLine("Enter again!");
    	}
    
    	evtToWait.Set();
    }
    
    static void Main(string[] args)
    {
    		Thread status = new Thread(ReadDataFromConsole);
    		status.Start();
    		
    		evtToWait = new ManualResetEvent(false);
    
    		evtToWait.WaitOne(5000); // wait for evtToWait.Set() or timeOut
    		
    		status.Abort(); // exit anyway
    		return;
    }
