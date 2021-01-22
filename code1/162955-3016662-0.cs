    public void Dispose()
    {
        if (IsAcquired)
            try
            { mutex.ReleaseMutex(); }
            catch (System.Threading.SynchronizationLockException)
            {
                // Handle the exception, assuming you need to do anything.
                // All other exceptions would still be passed up the stack.
            }
    }
