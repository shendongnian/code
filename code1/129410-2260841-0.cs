    private void StartImport()
    {
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.RunWorkerAsync();
    }
    
    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // do some work simulating a lenghy process which occasionally
        // reports progress with data back to the caller
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(200);
            backgroundWorker.ReportProgress(i, "Item No " + i.ToString());
        }
    }
    
    private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        listBox.Items.Add(e.UserState.ToString());
    }
