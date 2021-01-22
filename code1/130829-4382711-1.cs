        /// <summary>
    /// Utiltity for checking if a lock has already been acquired.
    /// WARNING: This test isn't actually thread-safe, 
    /// it's only really useful for unit tests
    /// </summary>
    private static bool ObjectIsAlreadyLockedByThisThread(object lockObject)
    {
        if (!Monitor.TryEnter(lockObject))
        {
            // another thread has the lock
            return false;
        }
        Monitor.Exit(lockObject);
        bool? LockAvailable = null;
        var T = new Thread(() =>
        {
            if (Monitor.TryEnter(lockObject))
            {
                LockAvailable = true;
                Monitor.Exit(lockObject);
            }
            else
            {
                LockAvailable = false;
            }
        });
        T.Start();
        T.Join();
        return !LockAvailable.Value;
    }
    // Tests:
    public static void TestLockedByThisThread()
    {
        object MyLock = new object();
        lock (MyLock)
        {
            bool WasLocked = ObjectIsAlreadyLockedByThisThread(MyLock);
            Debug.WriteLine(WasLocked); // prints "True"
        }
    }
    public static void TestLockedByOtherThread()
    {
        object MyLock = new object();
            
        var T = new Thread(() =>
        {
            lock (MyLock)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        });
        T.Start();
        Thread.Sleep(TimeSpan.FromSeconds(1));
        bool WasLocked = ObjectIsAlreadyLockedByThisThread(MyLock);
        T.Join();
        Debug.WriteLine(WasLocked); // prints "False"
    }
    public static void TestNotLocked()
    {
        object MyLock = new object();
        bool WasLocked = ObjectIsAlreadyLockedByThisThread(MyLock);
        Debug.WriteLine(WasLocked); // prints "False"
    }
