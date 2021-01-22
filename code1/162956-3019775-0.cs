    public void Dispose()
    {
        if (IsAcquired)
        {
            lock (mutex) 
            {
                mutex.ReleaseMutex();
                IsAcquired = false;
            }
        }
    }
