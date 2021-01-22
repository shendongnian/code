    class ILockMySelf
    {
        void doThat()
        {
            lock(this){ ... }
        }
    }
    class WeveGotAProblem
    {
        ILockMySelf anObjectIShouldntUseToLock;
        void doThis()
        {
            lock(anObjectIShouldntUseToLock)
            {
                // Following line should run in a separate thread
                // for the deadlock to happen
                anObjectIShouldntUseToLock.doThat();
            }
        }
    }
