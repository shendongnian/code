    private static void ProcessDataInParallel(byte[] data)
    
    {
        // use ConcurrentQueue to enable safe enqueueing from multiple threads.
        var exceptions = new ConcurrentQueue<Exception>();
    
        // execute the complete loop and capture all exceptions
        Parallel.ForEach(data, d =>
        {
            try
            {
                // something that might fail goes here...
            }
            // accumulate stuff, be patient ;)
            catch (Exception e) { exceptions.Enqueue(e); }
        });
    
        // check whether something failed?..
        if (exceptions.Count > 0) // do whatever you like ;
    }
