    // Run this as a LINQPad program in "Release Mode".
    // ~ It will never terminate on .NET 4.5.2 / x64. ~
    // The program will terminate in "Debug Mode" and may terminate
    // in other CLR runtimes and architecture targets.
    class X {
        // Adding {volatile} would 'fix the problem', as it disables the JIT
        // optimization that results in the non-terminating code.
    	public int terminate = 0;
    	public int y;
    
    	public void Run() {
    		var r = new ManualResetEvent(false);
    	    var t = new Thread(() => {
    	        int x = 0;
    			r.Set();
                // Using Volatile.Read or otherwise establishing
                // an Acquire Barrier would disable the 'bad' optimization.
    	        while(terminate == 0){x = x * 2;}
    			y = x;
    	    });
    
    		t.Start();
    		r.WaitOne();
    		Interlocked.Increment(ref terminate);
    	    t.Join();
    	    Console.WriteLine("Done: " + y);
    	}
    }
    
    void Main()
    {
    	new X().Run();
    }
