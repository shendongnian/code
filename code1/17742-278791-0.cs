    private void button1_Click(object sender, EventArgs e)
    {
        var fw = new System.IO.FileSystemWatcher();
        // Monitor changes to PNG files in C:\temp and subdirectories
        fileWatcher.Path = @"C:\temp";
        fileWatcher.IncludeSubdirectories = true;
        fileWatcher.Filter = @"*.png";
        // Attach event handlers to handle each file system events
        fileWatcher.Changed += fileChanged;
        fileWatcher.Created += fileCreated;
        fileWatcher.Renamed += fileRenamed;
        // Start monitoring!
        fileWatcher.EnableRaisingEvents = true;
    }
    void fileRenamed(object sender, System.IO.FileSystemEventArgs e)
    {
        // a file has been renamed!
    }
    void fileCreated(object sender, System.IO.FileSystemEventArgs e)
    {
        // a file has been created!
    }
    void fileChanged(object sender, System.IO.FileSystemEventArgs e)
    {
        // a file is modified!
    }
