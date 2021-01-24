    public static class ReaderWriterLockSlimExtensions
    {
        public static ExecuteWrite(this ReaderWriterLockSlim lock, Action action)
        {
            lock.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                lock.ExitWriteLock();
            }
        }
        public static ExecuteRead(this ReaderWriterLockSlim lock, Action action)
        {
            lock.EnterReadLock();
            try
            {
                action();
            }
            finally
            {
                lock.ExitReadLock();
            }
        }
    }
