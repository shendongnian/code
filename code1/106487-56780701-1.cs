        private static int _fileSystemWatcherCounts;
        private async void OnChanged(object sender, FileSystemEventArgs e)
        {
            // Filter several calls in short period of time
            Interlocked.Increment(ref _fileSystemWatcherCounts);
            await Task.Delay(100);
            if (Interlocked.Decrement(ref _fileSystemWatcherCounts) == 0)
                DoYourWork();
        }
