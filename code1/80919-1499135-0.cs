    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Example heavy operation
        for (int i = 0; i <= 999999; i++)
        {
            // Sleep for 10ms to simulate work
            System.Threading.Thread.Sleep(10);
    
            // Report the progress now
            this.backgroundWorker.ReportProgress(i);
    
            // Cancel process if it was flagged to be stopped.
            if (this.backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }
    }
