    int tasks = <however many tasks you're performing>;
    
    // Dispose when done.
    using (var e = new CountdownEvent(tasks))
    {
        // Queue work.
        ThreadPool.QueueUserWorkItem(() => {
            // Do work
            ...
    
            // Signal when done.
            e.Signal();
        });
    
        // Wait till the countdown reaches zero.
        e.WaitOne();
    }
