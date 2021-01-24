    private FileSystemWatcher fsWatcher;
    
    public void SetupWatcher()
    {
       fsWatcher = new FileSystemWatcher();
       fsWatcher.Path = @"C:\SomePath\SomeSubFolder\";
       fsWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;
       fsWatcher.Filter = "*.*";
       fsWatcher.Changed += FsWatcher_Changed;
       fsWatcher.EnableRaisingEvents = true;
    
       System.IO.File.WriteAllText(fsWatcher.Path + "MyFile.txt", "testing" );
    }
    
    private void FsWatcher_Changed(object sender, FileSystemEventArgs e)
    {
       var msg = "Action " + e.ChangeType + "\r\n"
               + "FullPath " + e.FullPath + "\r\n"
               + "Just File Name " + e.Name;
    
       MessageBox.Show(msg);
    }
