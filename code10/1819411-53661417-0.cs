    public Task DownloadContentAsync(CancellationToken cancellationToken)
    {
      // download content here
    }
    
    public async Task RunAsync()
    {
      var succeeded = false;
      while(!succeeded)
      {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
        await DownloadContentAsync(cts.Token)
         .ContinueWith((x) => succeeded = x.IsCompleted);
      }
    }
