    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // assuming the Minimum = 0 and Maximum = 100 on progressBar
        progressBar.Value = e.ProgressPercentage;
    }
