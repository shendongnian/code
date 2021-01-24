    public void PerformDownload()
    {
      ProgressForm = new frmProgress("your text");
      ProgressForm.ShowInTaskbar = false;
      backgroundWorker1.RunWorkerAsync();
      ProgressForm.ShowDialog();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
       //perform service request
       //if any of your task gets compeleted just call
       //ProgressForm.PrgBarInc()
    }
        
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        ProgressForm.Close();
        ProgressForm.Dispose();
    }
