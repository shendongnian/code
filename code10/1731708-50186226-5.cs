    private BlockingCollection<ImportFileInfo> RequestQueue = new BlockingCollection<ImportFileInfo>();
    private bool IsServiceEnabled;
    private readonly int MaxNumberOfThreads = 8;
    private Semaphore Semaphore = new Semaphore(numberOfThreads);
            
    public void UploadAndImport(ImportFileInfo request) 
    {            
      // Start the request handler background loop
      if (!this.IsServiceEnabled)
      {
        this.RequestQueue?.Dispose();
        this.RequestQueue = new BlockingCollection<ImportFileInfo>();
    
        // Fire and forget (requirement 4)
        Task.Run(() => HandleRequests());
        this.IsServiceEnabled = true;
      }
      // Cache multiple incoming client requests (requirement 1)
      this.RequestQueue.Add(request);
    }
    
    private void HandleRequests()
    {
      while (!this.RequestQueue.IsCompleted)
      {    
        ProcessRequest();
      }
      
      // Reset the request handler after BlockingCollection was marked completed
      this.IsServiceEnabled = false;
      this.RequestQueue.Dispose();
    }
        
    private void ProcessRequest()
    {
      var request = this.RequestQueue.Take();
      ImportFile(request);    
    }
