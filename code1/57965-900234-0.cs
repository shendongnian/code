    BackgroundWorker bw = new BackgroundWorker();
    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
    bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
    bw.RunWorkerAsync(arg);
    ...
            
    static void bw_DoWork(object sender, DoWorkEventArgs e)
    {
    	BackgroundWorker worker = (BackgroundWorker)sender;
    	int arg = (int)e.Argument;
    	e.Result = CallWebService(arg, e);
    }
    static void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	progressBar.Increment();
    }
    static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	label.Text = "Done: " + e.Result.ToString();
    }
