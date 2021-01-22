    protected override void OnStart(string[] args)
    {
        var worker = new BackgroundWorker();
        worker.DoWork += DoSomeLongOperation;
        worker.RunWorkerAsync();
    }
    private void DoSomeLongOperation(object sender, DoWorkEventArgs e)
    {
       // do your long operation...
    }
