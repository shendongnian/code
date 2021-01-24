    private static int secondsLeft;
    private static BackgroundWorker bgWorker;
    static void Main(string[] args)
    {
        secondsLeft = 30;
        bgWorker = new BackgroundWorker();
        bgWorker.DoWork += bgWorker_DoWork;
        bgWorker.ProgressChanged += bgWorker_ProgressChanged;
        bgWorker.WorkerReportsProgress = true;
        bgWorker.RunWorkerAsync();
        Console.ReadLine();
    }
    private static void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        while (secondsLeft >= 0)
        {
            bgWorker.ReportProgress(secondsLeft);
            Thread.Sleep(1000);
            secondsLeft--;
        }
    }
    private static void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Console.WriteLine($"Seconds left: {e.ProgressPercentage}");
    }
