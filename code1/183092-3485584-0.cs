    object locker = new object();
    private void Run()
    {
        while (!_isQuitting)
        {
            lock (locker)
            {
                Monitor.Wait(locker);
                DoStuff(jobData);
            }
        }
        DoCleanupStuff();
    }
    public void AddJob(object param)
    {
        // Obtain the lock first so that you don’t
        // change jobData while the thread is processing it
        lock (locker)
        {
            jobData = param;
            Monitor.Pulse(locker);
        }
    }
    public void Stop()
    {
        lock (locker)
        {
            _isQuitting = true;
            Monitor.Pulse(locker);
        }
        // Wait for the thread to finish — no need for _isFinished
        _thread.Join();
    }
