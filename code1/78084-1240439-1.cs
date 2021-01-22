    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Timers;
    
    namespace FolderSyncing
    {
        public class FTPFileSystemWatcher 
        {
            private readonly string _path;
            public event FileSystemEventHandler FTPFileCreated;
            public event FileSystemEventHandler FTPFileDeleted;
            public event FileSystemEventHandler FTPFileChanged;
    
            private Dictionary<string, LastWriteTime> _createdFilesToCheck;
            private readonly object _lockObject = new object();
            private const int _milliSecondsSinceLastWrite = 5000;
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
                _path = path;
                _baseWatcher = new FileSystemWatcher(path);
                SetUpEventHandling();
            }
    
            private void SetUpEventHandling()
            {
                _createdFilesToCheck = new Dictionary<string, LastWriteTime>();
                Timer copyTimer = new Timer(_createdCheckTimerInterval);
                copyTimer.Elapsed += copyTimer_Elapsed;
                copyTimer.Enabled = true;
                copyTimer.Start();
                _baseWatcher.EnableRaisingEvents = true;
                _baseWatcher.Created += _baseWatcher_Created;
                _baseWatcher.Deleted += _baseWatcher_Deleted;
                _baseWatcher.Changed += _baseWatcher_Changed;
            }
    
            void copyTimer_Elapsed(object sender, ElapsedEventArgs e)
            {
                lock (_lockObject)
                {
                    Console.WriteLine("Checking : " + DateTime.Now);
                    DateTime dateToCheck = DateTime.Now;
                    List<string> toRemove = new List<string>();
                    foreach (KeyValuePair<string, LastWriteTime> fileToCopy in _createdFilesToCheck)
                    {
                        FileInfo fileToCheck = new FileInfo(_path + fileToCopy.Key);
                        TimeSpan difference = fileToCheck.LastWriteTime - fileToCopy.Value.Date;
                        fileToCopy.Value.Update(fileToCopy.Value.Date.AddMilliseconds(difference.TotalMilliseconds));
                        if (fileToCopy.Value.Date.AddMilliseconds(_milliSecondsSinceLastWrite) < dateToCheck)
                        {
                            FileSystemEventArgs args = new FileSystemEventArgs(WatcherChangeTypes.Created, _path, fileToCopy.Key);
                            toRemove.Add(fileToCopy.Key);
                            InvokeFTPFileCreated(args);
                        }
                    }
                    foreach (string removal in toRemove)
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
                    _createdFilesToCheck.Add(e.Name,new LastWriteTime(fileToCopy.LastWriteTime));
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
    
        public class LastWriteTime
        {
            private DateTime _date;
    
            public DateTime Date
            {
                get { return _date; }
            }
    
            public LastWriteTime(DateTime date)
            {
                _date = date;
            }
    
            public void Update(DateTime dateTime)
            {
                _date = dateTime;
            }
    
    
            
        }
    }
