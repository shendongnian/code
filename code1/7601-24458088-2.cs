    public class BackgroundWorkerEx : BackgroundWorker
    {
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private bool _resetting, _started;
        private object _lockObject = new object();
        public void CancelSync()
        {
            bool doReset = false;
            lock (_lockObject) {
                if (_started && !_resetting) {
                    _resetting = true;
                    doReset = true;
                }
            }
            if (doReset) {
                CancelAsync();
                _resetEvent.WaitOne();
                lock (_lockObject) {
                    _started = false;
                    _resetting = false;
                }
            }
        }
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            lock (_lockObject) {
                _resetting = false;
                _started = true;
                _resetEvent.Reset();
            }
            try {
                base.OnDoWork(e);
            } finally {
                _resetEvent.Set();
            }
        }
    }
