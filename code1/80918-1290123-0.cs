    protected void OnClick( object sender, EventArgs e )
    {
         BackgroundWorker bg = new BackgroundWorker();
         bg.DoWork += new DoWorkEventHandler(bg_DoWork);
         bg.RunWorkerAsync();
    }
    
    void bg_DoWork(object sender, DoWorkEventArgs e)
    {
         BackgroundWorker worker = sender as BackgroundWorker;
         CallLongRunningFunction(); // will take 5 secs
    }
