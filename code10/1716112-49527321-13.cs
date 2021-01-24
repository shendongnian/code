    BackgroundWorker backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
    this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    //Add In your method which initiates download 
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
