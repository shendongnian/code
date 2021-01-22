    public class WorkerObject
    {
        private volatile int _active = 0;
        private Thread _t;
        private void DoWork()
        {
            while(_active == 1)
            {
                // do work
            }
            _t = null;
        }
        public void Start()
        {
            _active = 1;  
            _t = new Thread(DoWork);
            _t.Start();
        }
        public void Stop()
        {
           // safely communicate between threads.
           InterLocked.Exchange(ref _active, 0);
        }
    }
