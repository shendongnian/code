    public class ThreadUsingClass
    {
        private object mSyncObject = new object();
        private bool mKillThread = false;
        private Thread mThread = null;
        void Start()
        {
            // start mThread
        }
    
        void Stop()
        {
            lock(mSyncObject)
            {
                mKillThread = true;
            }
            mThread.Join();
        }
    
        void ThreadProc()
        {
            while(true)
            {
                bool isKilled = false;
                lock(mSyncObject)
                {
                    isKilled = mKilledThread;
                }
                if (isKilled)
                    return;
            }
        }    
    }
