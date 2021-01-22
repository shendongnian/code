    // Called by thread
    void MyThreadOperation()
    {
       while(!stopped)
       {
          // This is poor design in terms of performance.
          // Consider using a ResetEvent instead.
          Thread.Sleep(5000);
          try
          {
             doFTPDownload();
          }
          catch(Exception ex)
          {
             logMessage(ex.ToString());
          }
       }
    }
