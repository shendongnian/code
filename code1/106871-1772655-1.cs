        static void Main(string[] args)
        {
            size BackupSize = new size();
            BackupSize.GetSize("path");
            BackupSize.ProgressEvent += new ProgressEventHandler(BackupSize_ProgressEvent);
            Console.ReadLine();
        }
        static void BackupSize_ProgressEvent(object source, int progress)
        {
            Console.WriteLine(String.Format("Progress: {0}", progress));
        }
    }
    public delegate void ProgressEventHandler(object source, int progress);
    public class size
    {
        private readonly BackgroundWorker backgroundWorker;
        public event ProgressEventHandler ProgressEvent;
        public size()
        {
            backgroundWorker = new BackgroundWorker { WorkerReportsProgress = true };
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
        }
        public void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // do something with progress
            ProgressEvent.Invoke(sender, e.ProgressPercentage);
        }
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Get the size of the Here
                // Report the Progress
                backgroundWorker.ReportProgress(i);
            }
        }
        public void GetSize(String path)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
