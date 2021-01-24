     public class ProgressBarEvent
    {
        private static ProgressBarEvent _instance;
        public static ProgressBarEvent GetInstance()
        {
            if(_instance == null)
                _instance = new ProgressBarEvent();
            return _instance;
        }
        public EventHandler<int> ProgressChanged;
        public EventHandler Show;
        public EventHandler Close;
        public ProgressBarEvent Start()
        {
            OnShow();
            return this;
        }
        public ProgressBarEvent Stop()
        {
            OnStop();
            return this;
        }
        private void OnShow()
        {
            if (Show is EventHandler show)
            {
                show.Invoke(this, new EventArgs());
            }
        }
        private void OnStop()
        {
            if (Close is EventHandler close)
            {
                close.Invoke(this, new EventArgs());
            }
        }
        public void SendProgress(int progress)
        {
            if (ProgressChanged is EventHandler<int> progressChanged)
            {
                progressChanged.Invoke(this, progress);
            }
        }
    }
