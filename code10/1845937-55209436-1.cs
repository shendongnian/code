    void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker backGroundWorker = (BackgroundWorker)sender;
        for (int i = 0; i <= 100; i += 5)
        {
            Thread.Sleep(50);
            backgroundWorker.ReportProgress(i);
        }
    }
