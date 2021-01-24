    BackgroundWorker backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
    public void PrgBarInc()
    {
      if (this.IsHandleCreated)
      {
        if (this.InvokeRequired)
        {
           this.Invoke(new MethodInvoker(PrgBarInc));
        }
        else
        {
            int numberTotalTables = 22;
            progressBar1.Value = (numberTableProcessed / numberTotalTables) * 100;
            prgBar.Increment(numberTotalTables );
        }
    }
    
    this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
    
