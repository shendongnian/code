    BackgroundWorkerEx _worker;
    
    void StartWork()
    {
        StopWork();
        _worker = new BackgroundWorkerEx { 
            WorkerSupportsCancellation = true,
            WorkerReportsProgress = true
        };
        _worker.DoWork += Worker_DoWork;
        _worker.ProgressChanged += Worker_ProgressChanged;
    }
    void StopWork()
    {
        if (_worker != null && _worker.IsBusy) {
            _worker.CancelSync(); // Use our new method.
        }
    }
    
    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        for (int i = 1; i <= 20; i++) {
            if (worker.CancellationPending) {
                e.Cancel = true;
                break;
            } else {
                // Simulate a time consuming operation.
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress(5 * i);
            }
        }
    }
    private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressLabel.Text = e.ProgressPercentage.ToString() + "%";
    }
