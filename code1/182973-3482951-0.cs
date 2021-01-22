    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Executed on GUI thread.
        if (e.Error != null)
        {
            // Background thread errored - report it in a messagebox.
            MessageBox.Show(e.Error.ToString());
            return;
        }
        // Worker succeeded.
    }
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // Executed on GUI thread.
        progressBar1.Value = e.ProgressPercentage;
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Executed on ThreadPool thread.
        int max = (int)e.Argument;
        for (long i = 0; i < max; i++)
        {
            worker.ReportProgress(Convert.ToInt32(i));
        }
    }
 
