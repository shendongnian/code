    BackgroundWorker backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
    public void UpdateProgressBar(int numberTableProcessed)
    {
      if (this.IsHandleCreated)
      {
        if (this.InvokeRequired)
        {
            this.Invoke((MethodInvoker)delegate{UpdateProgressBar(numberTableProcessed);});
        }
        else
        {
            int numberTotalTables = 22;
            progressBar1.Value = (numberTableProcessed / numberTotalTables) * 100;
            prgBar.Increment(numberTotalTables );
        }
    }
    
    this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
    
