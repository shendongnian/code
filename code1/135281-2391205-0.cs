    // Main thread is Thread A
    object myLock = new Object();
    AutoResetEvent myEvent = new AutoResetEvent(false);
    ManualResetEvent completedEvent = new ManualResetEvent(false);
    ThreadPool.QueueUserWorkItem(s =>
    {
        for (int i = 0; i < 10000; i++)
        {
            lock (myLock)
            {
                // Do some work
            }
        }
        completedEvent.Set();
    });  // Thread B
    ThreadPool.QueueUserWorkItem(s =>
    {
        for (int i = 0; i < 10000; i++)
        {
            myEvent.WaitOne();
            lock (myLock)
            {
                // Do some work
            }
        }
    });  // Thread C
    // Main loop for thread A
    while (true)
    {
        lock (myLock)
        {
            // Do some work
            if (SomeSpecialCondition)
                break;
            else
                myEvent.Set();
        }
    }
    completedEvent.WaitOne(); // Wait for B to finish processing
    if (SomeSpecialCondition) // If we terminated without signaling C...
        myEvent.Set();        // Now allow thread C to clean up
