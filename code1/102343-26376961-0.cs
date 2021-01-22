     private void LongOperation()
     {
            try
            {
              //the operation
              if (success){
                 //write a message to a status label
                 bgWorker.ReportProgress(1);
              }
              else{
                 //write a message to a status label
                 bgWorker.ReportProgress(2); 
              }              
            }
            catch(){...}
      }
      public void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs p)
      {
          int lstIndex = p.ProgressPercentage;
          lblStatus.Text = mssglist[lstIndex].ToString(); 
      }
