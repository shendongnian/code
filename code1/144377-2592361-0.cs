    private delegate void UpdateProgressBarDelegate();
    
    private void UpdateProgressBar()
    {
         if (this.progressBar1.InvokeRequired)
         {
             this.progressBar1.Invoke(new UpdateProgressBarDelegate());
         }
         else
         {
             //code to update progress bar
         }    
    }
