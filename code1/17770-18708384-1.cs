    static class ReaderWriterLockExtensions() {
        /// <summary>
        /// Allows you to enter and exit a read lock with a using statement
        /// </summary>
        /// <param name="readerWriterLockSlim">The lock</param>
        /// <returns>A new object that will ExitReadLock on dispose</returns>
        public static OnDispose ReadLock(this ReaderWriterLockSlim readerWriterLockSlim)
        {
            // Enter the read lock
            readerWriterLockSlim.EnterReadLock();
            // Setup the ExitReadLock to be called at the end of the using block
            return new OnDispose(() => readerWriterLockSlim.ExitReadLock());
        }
        /// <summary>
        /// Allows you to enter and exit a write lock with a using statement
        /// </summary>
        /// <param name="readerWriterLockSlim">The lock</param>
        /// <returns>A new object that will ExitWriteLock on dispose</returns>
        public static OnDispose WriteLock(this ReaderWriterLockSlim rwlock)
        {
            // Enter the write lock
            rwlock.EnterWriteLock();
            // Setup the ExitWriteLock to be called at the end of the using block
            return new OnDispose(() => rwlock.ExitWriteLock());
        }
    }
    /// <summary>
    /// Calls the finished action on dispose.  For use with a using statement.
    /// </summary>
    public class OnDispose : IDisposable
    {
        Action _finished;
        public OnDispose(Action finished) 
        {
            _finished = finished;
        }
        public void Dispose()
        {
            _finished();
        }
    }
