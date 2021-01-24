    Timer timer = new Timer(Timer_Tick, null, Timeout.Infinite, Timeout.Infinite);
    Mutex timerSync = new Mutex();
    private bool _disposed;
    void Dispose()
    {
         _disposed = true;
        ...
    }
    void Timer_Tick()
    {
        if (_disposed)
        {
            return;
        }
        ...
    }
