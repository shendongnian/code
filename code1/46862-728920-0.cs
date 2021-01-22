    class ILockMySelf
    {
        void doThis()
        {
            lock(this){ ... }
        }
    
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
            lock(anObjectIShouldntUseToLock){ anObjectIShouldntUseToLock.doThat(); }
        }
    }
