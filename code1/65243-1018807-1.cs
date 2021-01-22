    Using System;
    Using System.Threading;
    
    class Foo
    {
    	static AutoResetEvent autoEvent = new AutoResetEvent(false);
    
    	static void Main()
    	{
    		ThreadPoolQueueUserWorkItem(new WaitCallback(FireAway), autoEvent);
    		autoEvent.WaitOne(); // Will wait for thread to complete
    	}
    
    	static void FireAway(object stateInfo)
    	{
    		System.Threading.Thread.Sleep(5000);
    		Console.WriteLine("5 seconds later");
    		((AutoResetEvent)stateInfo).Set();
    	}
    }
