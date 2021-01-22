    BackgroundWorker _backgroundWorker = new BackgroundWorker();
    
    ...
    
    // Set up the Background Worker Events
    _backgroundWorker.DoWork += _backgroundWorker_DoWork;
    backgroundWorker.RunWorkerCompleted += 
        _backgroundWorker_RunWorkerCompleted;
    
    // Run the Background Worker
    _backgroundWorker.RunWorkerAsync(5000);
    
    ...
    
    // Worker Method
    void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do something
    }
    
    // Completed Method
    void _backgroundWorker_RunWorkerCompleted(
        object sender, 
        RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            statusText.Text = "Cancelled";
        }
        else if (e.Error != null) 
        {
            statusText.Text = "Exception Thrown";
        }
        else 
        {
            statusText.Text = "Completed";
        }
    }
