    _scannerTask = Task.Factory.StartNew(() =>
    {
      foreach (var dataSource in _dataSources)
      {
        try
        {
          _scanRunSemaphore.WaitAsync(_cancelSource.Token);
          ActiveDataSource = dataSource;
          _status = $"Performing deep scan - {ActiveDataSource.Name}";
          AllDeepScanners[ActiveDataSource.Name] = new DeepScanner(processors, extractor, _fileTypes, Job.Settings.SkipBinaries);
          ActiveScanner = AllDeepScanners[dataSource.Name];
          ActiveFileSystem = UsedFileSystems[ActiveDataSource.Name];
          // Subscribe to the progress updates.
          ActiveScanner.OnProgressUpdate += ActiveScanner_OnProgressUpdate;
          ActiveScanner.ScanAsync(ActiveFileSystem, _cancelSource.Token, _pauseSource.Token).Wait(); // This is where the inventory gets loaded.
          
          // Now unsubscribe to the progress updates.
          ActiveScanner.OnProgressUpdate -= ActiveScanner_OnProgressUpdate;
          
          _status = $"Saving deep scan results - {ActiveDataSource.Name}";
          _logger.Debug($"Storing Deep scan results belonged to data source '{dataSource.Name}'");
          dataSource.SaveDeepScanResults(ActiveFileSystem, services);
          _logger.Debug($"Storing Job Last Scanned info belonged to data source '{dataSource.Name}'");
          SaveLastScanned(services, dataSource);
        }
        // I'm not mentioning catch block 
      } });
    ...
    // Handle the progress updates.
    private void ActiveScanner_OnProgressUpdate(object sender, float percent)
    {
      // Here you can update your UI with the progress.
      // Note, in order to avoid cross-thread exceptions we need to invoke the
      // UI updates since this function will be called on a non-UI thread.
      if (progressLabel.InvokeRequired)
      {
        progressLabel.Invoke(new Action(() => ActiveScanner_OnProgressUpdate(sender, percent)));
      }
      else
      {
        progressLabel.Text = "Progress: " + progress;
      }
    }
