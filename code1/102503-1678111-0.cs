    class WorkManager: IStopNotifier
    {
        public event EventHandler StopRequested;
    
        protected void OnStopRequested()
        {
            if (StopRequested != null) StopRequested(this, new EventArgs());
        }
    
        public void StopAllWorkers()
        {
            OnStopRequested();
        }
        public Worker CreateWorker<T>()
            where T: Worker
        {
            var worker = new T(this);
            return worker;
        }
    }
    
    class abstract Worker: IDisposable
    {
        public Worker(IStopNotifier stopNotifier)
        {
            stopNotofier.StopRequested += HandleStopRequested;
        }
        private IStopNotifier m_stopNotifier;
        private bool m_stopRequested = false;
    
        internal void HandleStopRequested(object sender, EventArgs e)
        {
            m_stopRequested = true;
        }
        public void Dispose()
        {
            m_stopNotifier.StopRequested -= HandleStopRequested;
        }
    }
