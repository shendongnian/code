    bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        prgProgressBar.Value = e.ProgressPercentage;
    }
