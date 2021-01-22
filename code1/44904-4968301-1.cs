    public void TestWatcher()
    {
        using (var fileWatcher = new FileSystemWatcher())
        {
            
            string path = @"C:\sv";
            string file = "pos.csv";
            fileWatcher.Path = path;
            fileWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            fileWatcher.Filter = file;
            
            System.EventHandler onDisposed = (sender,args) =>
            {
               eve.Set();
            };
            
            FileSystemEventHandler onFile = (sender, fileChange) =>
            {
               fileWatcher.EnableRaisingEvents = false;
               Thread t = new Thread(new ParameterizedThreadStart(CopyFile));
               t.Start(fileChange.FullPath);
               if (fileWatcher != null)
               {
                   fileWatcher.Dispose();
               }
               proceed = false;
            };
            fileWatcher.Changed += onFile;
            fileWatcher.Created += onFile;
            fileWatcher.Disposed+= onDisposed;
            fileWatcher.EnableRaisingEvents = true;
            while (proceed)
            {
                if (!proceed)
                {
                    break;
                }
            }
        }
    }
    public void CopyFile(object sourcePath)
    {
        eve.WaitOne();
        var destinationFilePath = @"C:\sv\Co";
        if (!string.IsNullOrEmpty(destinationFilePath))
        {
            if (!Directory.Exists(destinationFilePath))
            {
                Directory.CreateDirectory(destinationFilePath);
            }
            destinationFilePath = Path.Combine(destinationFilePath, "pos.csv");
        }           
        File.Copy((string)sourcePath, destinationFilePath);
    }
