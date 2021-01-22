    private readonly BackgroundWorker worker = new BackgroundWorker ();
    public void SomeFormEventForStartingBackgroundTask ()
    {
        worker.DoWork += BackgroundTask_HotelCalifornia;
        worker.RunWorkerAsync ();
    }
    // semantically, you want to perform this task for lifetime of
    // application, you may even expect that calling CancelAsync
    // will out and out abort this method - that is incorrect.
    // CancelAsync will only set DoWorkEventArgs.Cancel property
    // to true
    private void BackgroundTask_HotelCalifornia (object sender, DoWorkEventArgs e)
    {
        for ( ; ;)
        {
            // because we never inspect e.Cancel, we can never leave!
        }
    }
    private void App_FormClosing(object sender, FormClosingEventArgs e)     
    {
        // [politely] request termination
        worker.CancelAsync();
        // [politely] wait until background task terminates
        while (worker.IsBusy);
    }
