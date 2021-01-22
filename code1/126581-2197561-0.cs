    void Stop() 
    { 
         ivFileSystemWatcher.EnableRaisingEvents = false;
    
         ivFileSystemWatcher.Changed -=  
            new FileSystemEventHandler(ivFileSystemWatcher_Changed); 
         ivFileSystemWatcher.Dispose(); 
    }
