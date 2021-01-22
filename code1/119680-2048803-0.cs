    class Logger
    {
        private AutoResetEvent _waitEvent = new AutoResetEvent(false);
        private object _locker = new object();
        private bool _isRunning = true;    
    
        public void Log(string msg)
        {
           lock(_locker) { queue.Enqueue(msg); }
        }
        public void FlushQueue()
        {
            _waitEvent.Set();
        }
        
        private void WorkerProc(object state)
        {
            while (_isRunning)
            {
                _waitEvent.WaitOne();
                // process queue, 
                // ***
            } 
        }
    }
