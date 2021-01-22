    class ILockMySelf
    {
        public void doThat()
        {
            lock (this)
            {
                // Don't actually need anything here.
                // In this example this will never be reached.
            }
        }
    }
    class WeveGotAProblem
    {
        ILockMySelf anObjectIShouldntUseToLock = new ILockMySelf();
        public void doThis()
        {
            lock (anObjectIShouldntUseToLock)
            {
                // doThat will wait for the lock to be released to finish the thread
                var thread = new Thread(x => anObjectIShouldntUseToLock.doThat());
                thread.Start();
                // doThis will wait for the thread to finish to release the lock
                thread.Join();
            }
        }
    }
