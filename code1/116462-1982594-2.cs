    ThreadPool.QueueUserWorkItem(o =>
    {
        try
        {
            using (var h = (o as WaitHandle))
            { 
                if (!h.WaitOne(100000))
                {
                    // Alert main thread of the timeout
                }
            }
        }
        finally
        {
            Interlocked.Decrement(ref actThreadCount);
        }
     }, wh);
