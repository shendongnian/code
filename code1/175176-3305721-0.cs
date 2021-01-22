    public class MyWorker {
        private System.Threading.ManualResetEvent mResetEvent;
        private volatile bool mIsAlive;
        private const int mTimeout = 6000000;
    
        public void Start()
        {
            if (mIsAlive == false)
            {
                mIsAlive = true;
                System.Threading.Thread thread = new System.Threading.Thread(new ThreadStart(RunThread));
                thread.Start();
            }
        }
    
        public void Stop()
        {
            mIsAlive = false;
            mResetEvent.Set();
        }
    
        public void RunThread()
        {
            while(mIsAlive)
            {
                //Reset the event -we may be restarting the thread.
                mResetEvent.Reset();
                    
                DoWork();
    
                //The thread will block on this until either the timeout expires or the reset event is signaled.
                mResetEvent.WaitOne(mTimeout);
            }
        }
    
        public void DoWork()
        {
            //...
        } }
