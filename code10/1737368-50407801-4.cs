    public static class Background
    {
        public static ManualResetEvent WorkerResetEvent = new ManualResetEvent(false);
        private static BackgroundWorker worker;
        public static BackgroundWorker Worker
        {
            get
            {
                if (worker == null)
                {
                    worker = new BackgroundWorker();
                    worker.DoWork += Worker_DoWork;
                }
                return worker;
            }
        }
        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkerAction?.Invoke();
            WorkerResetEvent.Set();
        }
        public static Action WorkerAction;
    }
