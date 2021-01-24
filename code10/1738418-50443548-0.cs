    private void buttonDelete_Click(object sender, EventArgs e)
    {
        // Start your task
        backgroundWorker.RunWorkerAsync();
    }
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    #region Write logic to delete files in this region
    
                    var totalFiles = 100;
    
                    for (int i = 1; i <= totalFiles; i++)
                    {                    
                        // Report progress
                        backgroundWorker.ReportProgress((i * totalFiles) / 100);
    
                        System.Threading.Thread.Sleep(200);
                    } 
                    
                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                try
                {
                    // Update prgores bar
                    progressBar.Value = e.ProgressPercentage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }  
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                try
                {
                    // Do further process when your task is completed
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }   
