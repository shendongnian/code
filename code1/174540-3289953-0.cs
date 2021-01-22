    public class CopySomethingAsync
    {
        private BackgroundWorker _BackgroundWorker;
        public event ProgressChangedEventHandler ProgressChanged;
        public CopySomethingAsync()
        {
            // [...] create background worker, subscribe DoWork and RunWorkerCompleted
            _BackgroundWorker.ProgressChanged += HandleProgressChanged;
        }
        private void HandleProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
                ProgressChanged.Invoke(this, e);
        }
    }
