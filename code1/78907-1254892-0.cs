    static int needsToBeThreadSafe = 0;
    static System.Threading.ReaderWriterLockSlim rwl = new System.Threading.ReaderWriterLockSlim();
    public static void M1()
    {
        try
        {
            rwl.EnterWriteLock();
            needsToBeThreadSafe = RandomNumber();
        }
        finally
        {
            rwl.ExitWriteLock();
        }
    }
    public static void M2()
    {
        try
        {
            rwl.EnterReadLock();
            print(needsToBeThreadSafe);
        }
        finally
        {
            rwl.ExitReadLock();
        }
    }
