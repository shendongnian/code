    private void btstart_Click(object sender, EventArgs e)
    {
		this.WindowState = FormWindowState.Minimized;
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = @"C:\test";
        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
        watcher.Created += new FileSystemEventHandler(watcher_FileCreated);
        watcher.EnableRaisingEvents = true;
    }
    public static bool Ready(string filename)
    {
        try
        {
            using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                return inputStream.Length > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
    void watcher_FileCreated(object sender, FileSystemEventArgs e)
    {
        string path1 = @"C:\test";
        string path2 = @"C:\test2";
        string files = @"*.*";
        string[] fileList = Directory.GetFiles(path1, files);
        foreach (string file in fileList)
        {
            if (Ready(file) == true)
            {
                File.Move(file, Path.Combine(path2, System.IO.Path.GetFileName(file)));
			}
        }
    }
