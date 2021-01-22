    int completedCallCount = 0;
    int targetCount = mAllPositions.Count;
    
    using (ManualResetEvent manualResetEvent = new ManualResetEvent(false))
    {
    	proxy.DoAsyncCallCompleted += (s, e) =>
    	{
    		if (Interlocked.Increment(ref completedCallCount) == targetCount)
    		{
    			manualResetEvent.Set();
    		}
    	};
    	
    	foreach (var position in mAllPositions)
    	{
    		proxy.DoAsyncCall(position);
    	}
    	
    	// This will wait until all the events have completed.
    	manualResetEvent.WaitOne();
    }
