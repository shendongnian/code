    public void AutoConnect()
    {
        string[] HardwareList = new string[] { "d1", "d4", "ds1_2", "ds4_2" };
        backgroundWorker1.RunWorkerAsync(HardwareList);
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    
        BackgroundWorker worker = sender as BackgroundWorker;
        string[] FileNames = e.Argument as string[];
        int i = 0;
     
        foreach (string FileName in FileNames)
        {
            try
            {
               ParseFile(FileName);
               worker.ReportProgress(i++);
               if (worker.CancellationPending) break;
            }
            catch{}
        }
    }
