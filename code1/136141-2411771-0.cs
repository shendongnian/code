    private readonly BackgroundWorker worker = new BackgroundWorker ();
    public void SomeFormEventForStartingBackgroundTask ()
    {
        worker.DoWork += BackgroundTask_NeverEnd;
        worker.RunWorkerAsync ();
    }
    // semantically, you want to perform this task for lifetime of
    // application, however it *really* will never end,
    private void BackgroundTask_NeverEnd (object sender, DoWorkEventArgs e)
    {
        for ( ; ;)
        {
        }
    }
    private void App_FormClosing(object sender, FormClosingEventArgs e)     
    {
        // [politely] request termination
        worker.CancelAsync();
        // [politely] wait until background task terminates
        while (worker.IsBusy);
    }
