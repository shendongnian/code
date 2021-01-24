    private ManualResetEvent _canExit = new ManualResetEvent(true);
    private DoBackgroundWork()
    {
        _canExit.Reset();
        backgroundWorker1.RunWorkerAsync(_canExit);
    }
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        
        // This foreground thread will keep the process alive but allow UI thread to end.
        new Thread(()=>
        {
            _canExit.WaitOne();
            _canExit.Dispose();
        }).Start();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        ManualResetEvent mre = (ManualResetEvent )e.Argument;
        
        // do your work.
        
        mre.Set();
    }
