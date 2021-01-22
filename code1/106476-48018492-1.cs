    FileSystemWatcher fileSystemWatcher;
    
    private void DirectoryWatcher_Start()
    {
        FileSystemWatcher fileSystemWatcher = new FileSystemWatcher
        {
            Path = @"c:\mypath",
            NotifyFilter = NotifyFilters.LastWrite,
            Filter = "*.*",
            EnableRaisingEvents = true
        };
        
        fileSystemWatcher.Changed += new FileSystemEventHandler(DirectoryWatcher_OnChanged);
    }
    private static void WaitUntilFileIsUnlocked(String fullPath, Action<String> callback, FileAccess fileAccess = FileAccess.Read, Int32 timeoutMS = 10000)
    {
        Int32 waitMS = 250;
        Int32 currentMS = 0;
        FileInfo file = new FileInfo(fullPath);
        FileStream stream = null;
        do
        {
            try
            {
                stream = file.Open(FileMode.Open, fileAccess, FileShare.None);
                stream.Close();
                callback(fullPath);
                return;
            }
            catch (IOException)
            {
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
            Thread.Sleep(waitMS);
            currentMS += waitMS;
        } while (currentMS < timeoutMS);
    }    
    private static Dictionary<String, DateTime> DirectoryWatcher_fileLastWriteTimeCache = new Dictionary<String, DateTime>();
    private void DirectoryWatcher_OnChanged(Object source, FileSystemEventArgs ev)
    {
        try
        {
            lock (DirectoryWatcher_fileLastWriteTimeCache)
            {
                DateTime lastWriteTime = File.GetLastWriteTime(ev.FullPath);
                if (DirectoryWatcher_fileLastWriteTimeCache.ContainsKey(ev.FullPath))
                {
                    if (DirectoryWatcher_fileLastWriteTimeCache[ev.FullPath].AddMilliseconds(500) >= lastWriteTime)
                        return;     // file was already handled
                }
                DirectoryWatcher_fileLastWriteTimeCache[ev.FullPath] = lastWriteTime;
            }
            Task.Run(() => WaitUntilFileIsUnlocked(ev.FullPath, fullPath =>
            {
                // do the job with fullPath...
            }));
            
        }
        catch (Exception e)
        {
            // handle exception
        }
    }
