    void Dispose()
    {
        timer.Change(Timeout.Infinite, Timeout.Infinite); //Stop timer
        
        var waiter = new ManualResetEvent(false);
        timer.Dispose(waiter);
        waiter.WaitOne();
        waiter.Dispose();
        timerSync.Dispose();
        //Dispose other things...
    }
