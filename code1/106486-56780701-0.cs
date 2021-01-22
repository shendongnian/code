        private static int _fileStystemWatcherCounts = 0;
        private async void OnChanged(object sender, FileSystemEventArgs e)
        {
            // Filter several calls in short period of times
            bool lastThread;
            Interlocked.Increment(ref _fileStystemWatcherCounts);
            await Task.Delay(100);
            if (Interlocked.Decrement(ref _fileStystemWatcherCounts) == 0)
                DoYourWork();
        }
