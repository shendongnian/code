    /// <summary>
    /// Utiltity for checking if a lock has already been acquired.
    /// WARNING: This test isn't actually thread-safe, 
    /// it's only really useful for unit tests
    /// </summary>
    private static bool ObjectWasUnlocked(object lockObject)
    {
        try
        {
            if (!Monitor.TryEnter(lockObject))
            {
                // another thread has the lock
                return false;
            }
        }
        finally
        {
            Monitor.Exit(lockObject);
        }
        bool AnotherThreadGotTheLock;
        var T = new Thread(() =>
        {
            if (Monitor.TryEnter(lockObject))
            {
                AnotherThreadGotTheLock = true;
                Monitor.Exit(lockObject);
            }
            else
            {
                AnotherThreadGotTheLock = false;
            }
        });
        T.Start();
        T.Join();
        return !AnotherThreadGotTheLock;
    }
    // Tests:
    public void TestLockingTrue()
    {
        object MyLock = new object();
        lock (MyLock)
        {
            bool WasAlreadyLocked = ObjectWasUnlocked(MyLock);
            Debug.Print(WasAlreadyLocked); // prints "true"
        }
    }
    public void TestLockingFalse()
    {
        object MyLock = new object();
        bool WasAlreadyLocked = ObjectWasUnlocked(MyLock);
        Debug.Print(WasAlreadyLocked); // prints "false"
    }
