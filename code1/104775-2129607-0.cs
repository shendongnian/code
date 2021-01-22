    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        while (!this.bgWorker.CancellationPending)
        {
            this.bgWorker.ReportProgress(Environment.TickCount);
            Thread.Sleep(1);
        }
    }
    private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        this.textBox1.Text = e.ProgressPercentage.ToString();
    }
