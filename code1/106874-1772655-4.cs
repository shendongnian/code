    class main
    {
        static void Main(string[] args)
        {
            size BackupSize = new size();
            BackupSize.GetSize("path");
            BackupSize.ProgressEvent += new ProgressEventHandler(BackupSize_ProgressEvent);
            // BackupSize.BackupSize will not be accurate until the thread is finished.
            // You may want to take that into consideration
            int SizeofBackup = (int)(((BackupSize.BackupSize) / 1024f) / 1024f) / 1024;
            Console.ReadLine();
        }
        static void BackupSize_ProgressEvent(object source, int progress)
        {
            Console.WriteLine(String.Format("Progress: {0}", progress));
        }
    }
    // This is the delegate that acts as the event handler for your progress events
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
            String Path = e.Argument as String;
            
            // Do something with Path;
            // Simulate work
            for (int i = 1; i <= 100; i++)
            {
                // Get the size of the Here
                // Report the Progress
                backgroundWorker.ReportProgress(i);        
                Thread.Sleep(10);
            }
        }
        public void GetSize(String path)
        {
            backgroundWorker.RunWorkerAsync(path);
        }
    }
