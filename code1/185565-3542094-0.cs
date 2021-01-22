    static bool isCancellationRequested = false;
    static object gate = new object();
    // request cancellation
    lock (gate)
    {
        isCancellationRequested = true;
    }
    // thread
    for (int i = 0; i < 100000; i++)
    {
        // simulating work
        Thread.SpinWait(5000000);
        lock (gate)
        {
            if (isCancellationRequested)
            {
                // perform cleanup if necessary
                //...
                // terminate the operation
                break;
            }
        }
    }
