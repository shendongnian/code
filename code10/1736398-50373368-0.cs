    const int UpdateCacheInterval = 300;
    // we use keyword volatile as we access this variable from different thread
    private volatile bool isRainingCache;
    private Task UpdateCacheTask { get; }
    // Use it to cancel background task when it's requred
    private CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
    private void InitializeCache()
    {
       UpdateCacheTask = Task.Run(() => 
       {
          Thread.Sleep(UpdateCacheInterval);
          isRainingCache = ExternalService.IsRaining();
       }, CancellationTokenSource.Token);
    }
    public bool IsRaining()
    {
        // set the UpdateCacheInterval to a short interval where it's not possible
        // that one second has expired from the time of the last check
        return isRainingCache;
    }
