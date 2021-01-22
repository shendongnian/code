    class Myclass
    {
        ManualResetEvent _event;
        Thread _thread;
        public void Start()
        {
            _thread = new Thread(WorkerThread);
            _thread.IsBackground = true;
            _thread.Start();
        }
        public void Stop()
        {
            _event.Set();
            if (!_thread.Join(5000))
                _thread.Abort();
        }
        private void WorkerThread()
        {
            while (true)
            {
                // wait 5 seconds, change to whatever you like
                if (_event.WaitOne(5000))
                    break; // signalled to stop
                //do something else here
            }
        }
    }
