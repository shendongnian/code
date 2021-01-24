    private async Task BackgroundProceessing()
    {
      var semaphore = new SemaphoreSlim (2);
    
      void HandleTask(Task task)
      {
        semaphore.Release();
      }
    
      while (!_shutdown.IsCancellationRequested)
      {
        await semaphore.WaitAsync();
        var item = await TaskQueue.DequeueAsync(_shutdown.Token);
    
        var task = item (_shutdown.Token);
        task.ContinueWith (HandleTask);
      }
    }
