    public class FileMonitor : IDisposable
    {
        private const int PollInterval = 5000;
        private FileSystemWatcher watcher;
        private HashSet<string> filesToProcess = new HashSet<string>();
        private Timer fileTimer;  // System.Threading.Timer
        public FileMonitor(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Created += new FileSystemEventHandler(FileCreated);
            watcher.EnableRaisingEvents = true;
            fileTimer = new Timer(new TimerCallback(ProcessFilesTimer),
                null, PollInterval, Timeout.Infinite);
        }
        public void Dispose()
        {
            fileTimer.Dispose();
            watcher.Dispose();
        }
        private void FileCreated(object source, FileSystemEventArgs e)
        {
            lock (filesToProcess)
            {
                filesToProcess.Add(e.FullPath);
            }
        }
        private void ProcessFile(FileStream fs)
        {
            // Your code here...
        }
        private void ProcessFilesTimer(object state)
        {
            string[] currentFiles;
            lock (filesToProcess)
            {
                currentFiles = filesToProcess.ToArray();
            }
            foreach (string fileName in currentFiles)
            {
                TryProcessFile(fileName);
            }
            fileTimer.Change(PollInterval, Timeout.Infinite);
        }
        private void TryProcessFile(string fileName)
        {
            FileStream fs = null;
            try
            {
                FileInfo fi = new FileInfo(fileName);
                fs = fi.OpenRead();
            }
            catch (IOException)
            {
                // Possibly log this error
                return;
            }
            using (fs)
            {
                ProcessFile(fs);
            }
            lock (filesToProcess)
            {
                filesToProcess.Remove(fileName);
            }
        }
    }
