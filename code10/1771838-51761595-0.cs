    class Program
    {
        private static BackgroundWorker _worker;
        static void Main(string[] args)
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += Worker_DoWork;
            _worker.ProgressChanged += Worker_ProgressChanged;
            _worker.WorkerReportsProgress = true;
            _worker.RunWorkerAsync();
            Console.ReadLine();
        }
        private static void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Progress is {0}", e.ProgressPercentage);
        }
        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            for (int i = 0; i < 100; ++i)
            {
                worker.ReportProgress(i); // Reporting progress in percent
                Thread.Sleep(50);
            }
        }
    }
