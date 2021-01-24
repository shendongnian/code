     private void keepchecking()
    {
    FileSystemWatcher wt = new FileSystemWatcher();
    wt.Path = path;
    wt.NotifyFilter = NotifyFilters.LastWrite;
    wt.Filter = "*.*";
    wt.Changed += new FileSystemEventHandler(OnChanged);
    wt.EnableRaisingEvents = true;
    }
     private void OnChanged(object source, FileSystemEventArgs e)
    {
     MessageBox.Show("New FIle Detected");
    }
