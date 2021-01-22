    private void button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
    }
    
    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        for (int i = 1; i <= 100; i++)
        {
            backgroundWorker1.ReportProgress(i);
            Thread.Sleep(100);
        }
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        this.progressBar1.Value = e.ProgressPercentage;
    }
