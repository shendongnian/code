    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    
    namespace FolderSyncing
    {
        public class FTPFileSystemWatcher 
        {
            private readonly string _path;
            public event FileSystemEventHandler FTPFileCreated;
            public event FileSystemEventHandler FTPFileDeleted;
            public event FileSystemEventHandler FTPFileChanged;
    
            private Dictionary<string, DateTime> _createdFilesToCheck;
            private readonly object _lockObject = new object();
            private const int _milliSecondsSinceLastWrite = 2100;
            private const int _createdCheckTimerInterval = 2000;
    
            private readonly FileSystemWatcher _baseWatcher;
    
            public FTPFileSystemWatcher(string path, string Filter)
            {
                _path = path;
                _baseWatcher = new FileSystemWatcher(path,Filter);
                SetUpEventHandling();
            }
    
            public FTPFileSystemWatcher(string path)
            {
                _baseWatcher = new FileSystemWatcher(path);
                SetUpEventHandling();
            }
    
            private void SetUpEventHandling()
            {
                _createdFilesToCheck = new Dictionary<string, DateTime>();
                Timer copyTimer = new Timer(FileCreatedCheck, null, 0, _createdCheckTimerInterval);
                _baseWatcher.EnableRaisingEvents = true;
                _baseWatcher.Created += _baseWatcher_Created;
                _baseWatcher.Deleted += _baseWatcher_Deleted;
                _baseWatcher.Changed += _baseWatcher_Changed;
            }
    
    
        private void FileCreatedCheck(object state)
        {
            lock (_lockObject)
            {
                 List<string> toRemove = new List<string>();
                foreach (KeyValuePair<string, DateTime> fileToCopy in _createdFilesToCheck)
                {
                    if (fileToCopy.Value.AddMilliseconds(_milliSecondsSinceLastWrite) < DateTime.Now)
                    {
                        FileSystemEventArgs args = new FileSystemEventArgs(WatcherChangeTypes.Created,_path,fileToCopy.Key);
                        toRemove.Add(fileToCopy.Key);
                        InvokeFTPFileCreated(args);
                    }
                }
                foreach(string removal in toRemove)
                {
                    _createdFilesToCheck.Remove(removal);
                }
            }
        }
    
            void _baseWatcher_Changed(object sender, FileSystemEventArgs e)
            {
                InvokeFTPFileChanged(e);
            }
    
            void _baseWatcher_Deleted(object sender, FileSystemEventArgs e)
            {
                InvokeFTPFileDeleted(e);
            }
    
            void _baseWatcher_Created(object sender, FileSystemEventArgs e)
            {
                if (!_createdFilesToCheck.ContainsKey(e.Name))
                {
                    FileInfo fileToCopy = new FileInfo(e.FullPath);
                    _createdFilesToCheck.Add(e.Name, fileToCopy.LastWriteTime);
                }
            }
    
            private void InvokeFTPFileChanged(FileSystemEventArgs e)
            {
                FileSystemEventHandler Handler = FTPFileChanged;
                if (Handler != null)
                {
                    Handler(this, e);
                }
            }
    
            private void InvokeFTPFileDeleted(FileSystemEventArgs e)
            {
                FileSystemEventHandler Handler = FTPFileDeleted;
                if (Handler != null)
                {
                    Handler(this, e);
                }
            }
    
            private void InvokeFTPFileCreated(FileSystemEventArgs e)
            {
                FileSystemEventHandler Handler = FTPFileCreated;
                if (Handler != null)
                {
                    Handler(this, e);
                }
            }
     
        }
    }
