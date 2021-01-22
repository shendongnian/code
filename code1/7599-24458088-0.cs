    public class BackgroundWorkerEx : BackgroundWorker
    {
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        public void CancelSync()
        {
            CancelAsync();
            _resetEvent.WaitOne();
        }
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            _resetEvent.Reset();
            try {
                base.OnDoWork(e);
            } finally {
                _resetEvent.Set();
            }
        }
    }
