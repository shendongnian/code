    public interface IHandler
    {
        void Foo();
        void Bar();
    }
    public class ThreadSafeHandler : IHandler
    {
    
        ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        IHandler wrappedHandler;
    
        public ThreadSafeHandler(IHandler handler)
        {
            wrappedHandler = handler;
        }
    
        public void Foo()
        {
            try
            {
                rwLock.EnterReadLock();
                wrappedHandler.Foo();
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }
    
        public void Bar()
        {
            try
            {
                rwLock.EnterReadLock();
                wrappedHandler.Foo();
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }
    
        public void SwapHandler(IHandler newHandler)
        {
            try
            {
                rwLock.EnterWriteLock();
                UnhookProtocol(wrappedHandler);
                HookProtocol(newHandler);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
    }
