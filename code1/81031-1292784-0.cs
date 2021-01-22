    void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // do it over again
        StartPolling((BackgroundWorker)sender);
    }
    public void StartPolling(BackgroundWorker worker)
    {
        worker.RunWorkerAsync();
    }
