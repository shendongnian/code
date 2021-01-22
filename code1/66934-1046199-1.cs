    static void Main(string[] args)
    {
    	List<ManualResetEvent> resetEvents = new List<ManualResetEvent>();
    	foreach (var x in Enumerable.Range(1, WORKER_COUNT))
    	{
    		ManualResetEvent resetEvent = new ManualResetEvent();
    		ThreadPool.QueueUserWorkItem(DoSomething, resetEvent);
            resetEvents.Add(resetEvent);
    	}
    
    	// wait for all ManualResetEvents
    	WaitHandle.WaitAll(resetEvents.ToArray()); // You probably want to use an array instead of a List, a list was just easier for the example :-)
    }
    
    public static void DoSomething(object data)
    {
    	ManualResetEvent resetEvent = data as ManualResetEvent;
    
    	// Do something
    
    	resetEvent.Set();
    }
