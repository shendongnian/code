    class MyBackgroundWorker
    {
        private BackgroundWorker _worker;
        private bool _isBusy;
    
        public void Start()
        {
            if (_isBusy)
                throw new InvalidOperationException("Cannot start as a background worker is already running.");
    
            InitialiseWorker();
            _worker.RunWorkerAsync();
        }
    
        public async Task StopAsync()
        {
            if (!_isBusy)
                throw new InvalidOperationException("Cannot stop as there is no running background worker.");
    
            _worker.CancelAsync();
    
            while (_isBusy)
                await Task.Delay(1);
            _worker.Dispose();
        }
    
        private void InitialiseWorker()
        {
            _worker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            _worker.DoWork += WorkerDoWork;
        }
    
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _isBusy = true;
            try
            {
                while (!_worker.CancellationPending)
                {
                    // Do something.
                }
            }
            catch
            {
                _isBusy = false;
                throw;
            }
            _isBusy = false;
        }
    }
