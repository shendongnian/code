    class Logger
    {
        private AutoResetEvent _waitEvent = new AutoResetEvent(false);
        private object _locker = new object();
        private bool _isRunning = true;    
    
        public void Log(string msg)
        {
           lock(_locker) { _queue.Enqueue(msg); }
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
                while(true)
                {
                    string s = null;
                    lock(_locker)
                    {
                       if (_queue.IsEmpty) 
                          break;
                       s = _queue.Dequeu();
                    }
                    if (s != null)
                      // process s
                }
            } 
        }
    }
