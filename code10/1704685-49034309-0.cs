           CaptureServerSettings appSettings = provider.GetRequiredService<CaptureServerSettings>();
           using (FileSystemWatcher directoryWatcher = new FileSystemWatcher(appSettings.WatchDirectory, "*.*"))
           {
                directoryWatcher.BeginInit();
                directoryWatcher.IncludeSubdirectories = false;
                directoryWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
                directoryWatcher.Created += createdEvent;
                directoryWatcher.Changed += changedEvent;
                directoryWatcher.EnableRaisingEvents = true;
                directoryWatcher.EndInit();
                provider.GetRequiredService<CancellationTokenSource>().Token.WaitHandle.WaitOne();
            }
