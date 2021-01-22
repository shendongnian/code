    // We create some actions...
    object locker = new object();
    
    Action action1 = () => {
    	lock (locker)
    	{
    		System.Threading.Monitor.Wait(locker);
    		Console.WriteLine("This is action1");
    	}
    };
    
    Action action2 = () => {
    	lock (locker)
    	{
    		System.Threading.Monitor.Wait(locker);
    		Console.WriteLine("This is action2");
    	}
    };
    
    // ... (stuff happens, etc.)
    
    // Imagine both actions were running
    // and there's 0 items in the queue
    
    // And now the producer kicks in...
    lock (locker)
    {
    	// This would add a job to the queue
    
    	Console.WriteLine("Pulse now!");
    	System.Threading.Monitor.Pulse(locker);
    }
    
    // ... (more stuff)
    // and the actions finish now!
    
    Console.WriteLine("Consume action!");
    action1(); // Oops... they're locked...
    action2();
