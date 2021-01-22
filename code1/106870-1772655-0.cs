    public class size
    {
        private BackgroundWorker backgroundWorker;
        public size()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
        }
        public static void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // do something with progress
        }
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
         
            for (int i = 1; i <= 100; i++)
            {
                // Get the size of the Here
                backgroundWorker.ReportProgress(i);
            }
        }
        public void GetSize(String path)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
