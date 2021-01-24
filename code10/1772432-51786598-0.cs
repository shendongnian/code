    static readonly object SomeLock = new object();
    using (var lck = new CodeLock()) 
    {
       var ok = lck.Lock(SomeLock, timeout) 
       // do stuff, connect to db
    }
    public struct CodeLock : IDisposable
    {
        private object lockedObject;
        private bool lockTaken;
        public bool Lock(object someLock, int timeout)
        {
            lockedObject = someLock;
            Monitor.TryEnter(someLock, timeout, ref lockTaken);
            if (lockTaken == false)
            {
                // didn't acquire lock within timeout
                return false;
            }
            return true;
        }
        public void Dispose()
        {
            if (lockedObject == null) return;
            if (lockTaken)
            {
                lockTaken = false;
                Monitor.Exit(lockedObject);
            }
        }
    }
