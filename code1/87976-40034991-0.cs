    public class FileAccessWatcher
    {
        // this list keeps track of files being watched
        private static ConcurrentDictionary<string, FileAccessWatcher> watchedFiles = new ConcurrentDictionary<string, FileAccessWatcher>();
        public static void RegisterWaitForFileAccess(string filePath)
        {
            // if the file is already being watched, don't do anything
            if (watchedFiles.ContainsKey(filePath))
            {
                return;
            }
            // otherwise, start watching it
            FileAccessWatcher accessWatcher = new FileAccessWatcher(filePath);
            watchedFiles[filePath] = accessWatcher;
            accessWatcher.StartWatching();
        }
        /// <summary>
        /// Event triggered when the file is finished copying or when the file size has not increased in the last 5 minutes.
        /// </summary>
        public static event FileSystemEventHandler FileFinishedCopying;
        private static readonly TimeSpan MaximumIdleTime = TimeSpan.FromMinutes(5);
        private readonly FileInfo file;
        private long lastFileSize = 0;
        private DateTime timeOfLastFileSizeIncrease = DateTime.Now;
        private FileAccessWatcher(string filePath)
        {
            this.file = new FileInfo(filePath);
        }
        private Task StartWatching()
        {
            return Task.Factory.StartNew(this.RunLoop);
        }
        private void RunLoop()
        {
            while (this.IsFileLocked())
            {
                long currentFileSize = this.GetFileSize();
                if (currentFileSize > this.lastFileSize)
                {
                    this.lastFileSize = currentFileSize;
                    this.timeOfLastFileSizeIncrease = DateTime.Now;
                }
                // if the file size has not increased for a pre-defined time limit, cancel
                if (DateTime.Now - this.timeOfLastFileSizeIncrease > MaximumIdleTime)
                {
                    break;
                }
            }
            this.RemoveFromWatchedFiles();
            this.RaiseFileFinishedCopyingEvent();
        }
        private void RemoveFromWatchedFiles()
        {
            FileAccessWatcher accessWatcher;
            watchedFiles.TryRemove(this.file.FullName, out accessWatcher);
        }
        private void RaiseFileFinishedCopyingEvent()
        {
            FileFinishedCopying?.Invoke(this,
                new FileSystemEventArgs(WatcherChangeTypes.Changed, this.file.FullName, this.file.Name));
        }
        private long GetFileSize()
        {
            return this.file.Length;
        }
        private bool IsFileLocked()
        {
            try
            {
                using (this.file.Open(FileMode.Open)) { }
            }
            catch (IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);
                return errorCode == 32 || errorCode == 33;
            }
            return false;
        }
    }
