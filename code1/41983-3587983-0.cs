        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            backgroundWorker1.ReportProgress(0, "A");
            Thread.Sleep(5000);
            backgroundWorker1.ReportProgress(0, "B");
            Thread.Sleep(5000);
            backgroundWorker1.ReportProgress(0, "C");
        }
        private void backgroundWorker1_ProgressChanged(
            object sender, 
            ProgressChangedEventArgs e)
        {
            label1.Text = e.UserState.ToString();
        }
