    public void Run(object sender, DoWorkEventArgs e)   
    {      
       BackgroundWorker worker = sender as BackgroundWorker;
       if(worker != null)
       {
          while (!worker.CancellationPending)   
          {
             DoWork();  
          }
       }
    }
