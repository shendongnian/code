    worker.RunWorkerCompleted += OnRunWorkerCompleted;
    //...
    public void OnRunWorkerCompleted(object s, RunWorkerCompletedEventArgs args)
    {
        if (InvokeRequired)
        {
            // not on the UI thread - use (Begin-)Invoke
            BeginInvoke(new RunWorkerCompletedEventHandler(OnRunWorkerCompleted), s, args);
            return;
        }
        
        // now we're on the UI thread
        progressBar1.Visible = false;// ProgressBarStyle.Marquee 
        btnGenerate.Enabled = true;   
    }
