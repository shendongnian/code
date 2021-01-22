    private readonly _lock = new object();
    private readonly _semaphore = new Semaphore(2, 2);
    
    private void DoWork()
    {
        if (_semaphore.WaitOne(0))
        {
            try
            {
                lock (_lock)
                {
                    // ...
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
