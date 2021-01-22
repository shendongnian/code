    protected override void OnStart(string[] args)
    {
        var worker = new BackgroundWorker();
        worker.DoWork += DoSomeLongOperation;
        worker.RunWorkerAsync();
    }
    private void DoSomeLongOperation_DoWork(object sender, DoWorkEventArgs e)
    {
       // do your long operation...
    }
