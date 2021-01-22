    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        for (int i = 0; i < allFiles.Length; i++)
        {
            localSize += allFiles[i].Length;
            localFiles++;
            
            // this you can pass to ReportProgress
            string statusText = allFiles[i].Name;
            
            int progressPercentage = (100 * i) / allFiles.Length;
            worker.ReportProgress(progressPercentage, statusText);
        }
    }
    
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // now that this is being done here, it is thread-safe
        string statusText = e.UserState as string;
        if (!string.IsNullOrEmpty(statusText))
        {
            toolStripStatusLabel.Text = statusText;
        }
        
        // your progress should be capped at the ProgressBar's Maximum,
        // rather than 100
        int progress = e.ProgressPercentage;
        int maxProgress = fileRetrievalProgressBar.Maximum;
        fileRetrievalProgressBar.Value = Math.Min(progress, maxProgress);
    }
