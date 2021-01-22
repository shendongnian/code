    class LockManager<TKey>
    {
        private Dictionary<TKey, List<EventWaitHandle>> locks =
            new Dictionary<TKey, List<EventWaitHandle>>();
        private Object syncRoot = new Object();
        public void Lock(TKey key)
        {
            do
            {
                Monitor.Enter(syncRoot);
                List<EventWaitHandle> waiters = null;
                if (true == locks.TryGetValue(key, out waiters))
                {
                    // Key is locked, add ourself to waiting list
                    // Not that this code is not safe under OOM conditions
                    AutoResetEvent eventLockFree = new AutoResetEvent(false);
                    waiters.Add(eventLockFree);
                    Monitor.Exit(syncRoot);
                    // Now wait for a notification
                    eventLockFree.WaitOne();
                }
                else
                {
                    // event is free
                    waiters = new List<EventWaitHandle>();
                    locks.Add(key, waiters);
                    Monitor.Exit(syncRoot);
                    // we're done
                    break;
                }
            } while (true);
        }
        public void Release(TKey key)
        {
            List<EventWaitHandle> waiters = null;
            lock (syncRoot)
            {
                if (false == locks.TryGetValue(key, out waiters))
                {
                    Debug.Assert(false, "Releasing a bad lock!");
                }
                locks.Remove(key);
            }
            // Notify ALL waiters. Unfair notifications
            // are better than FIFO for reasons of lock convoys
            foreach (EventWaitHandle waitHandle in waiters)
            {
                waitHandle.Set();
            }
        }
    }
