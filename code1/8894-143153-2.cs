    public class Worker
    {
        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        ManualResetEVent _pauseEvent = new ManualResetEvent(true);
        Thread _thread;
        
        public Worker() { }
        
        public void Start()
        {
            _thread = new Thread(DoWork);
            _thread.Start();
        }
        
        public void Pause()
        {
            _pauseEvent.Reset();
        }
        
        public void Resume()
        {
            _pauseEvent.Set();
        }
        
        public void Stop()
        {
            // Signal the shutdown event
            _shutdownEvent.Set();
            
            // Make sure to resume any paused threads
            _pauseEvent.Set();
            
            // Wait for the thread to exit
            _thread.Join();
        }
        
        public void DoWork()
        {
            while (true)
            {
                _pauseEvent.WaitOne(Timeout.Infinite);
                
                if (_shutdownEvent.WaitOne(0))
                    break;
                
                // Do the work..
            }
        }
    }
