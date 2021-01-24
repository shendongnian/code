    private BackgroundWorker backgroundWorker1;
    this.backgroundWorker1 = new BackgroundWorker(); 
    this.backgroundWorker1.DoWork += new 
            DoWorkEventHandler(this.backgroundWorker1_DoWork);
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundProcessLogicMethod();
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender,
    
        RunWorkerCompletedEventArgs e)
    {
      if (e.Error != null) MessageBox.Show(e.Error.Message);
        else MessageBox.Show(e.Result.ToString());
    } 
    
    private void StartButton_Click(object sender, EventArgs e)
    
    {
        // Start BackgroundWorker
        backgroundWorker1.RunWorkerAsync(2000);
    }
