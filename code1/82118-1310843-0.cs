    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        WebClient wc = new WebClient();
        int count = urlsToCheck.Count;
        for(int i = 0; i < count; i++)
        {
            bool urlValid = CheckUrl(url);
            backgroundWorker1.ReportProgress(100 * (i + 1) / count, new CheckUrlResult(url, urlValid));
        }
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        CheckUrlResult result = e.UserState as CheckUrlResult;
        textBox1.Text += string.Format("{0} : {1}\n", result.Url, result.IsValid);
        progressBar1.Value = e.ProgressPercentage;
    }
