    FileSystemWatcher watcher = new FileSystemWatcher();
    
    void Main()
    {
    	// get file from OFD etc
    	watcher.Path = @"c:\temp";
    	watcher.Filter = "myfile.txt";
    	watcher.Changed += OnChanged;
    	watcher.EnableRaisingEvents = true;
    	
    	// needed for this example as a console app doesn't have an 
        // event loop unlike Windows Forms
    	while (true) {
    		Thread.Sleep(100);
    	}
    }
    
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
    	string line = null;
    	using (FileStream logFileStream = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    	using (StreamReader logFileReader = new StreamReader(logFileStream))
    	{
    
    		while (!logFileReader.EndOfStream)
    		{
    			line = logFileReader.ReadLine();
    		}
    	}
    
    	// Event fires twice unders some circumstances
    	// https://stackoverflow.com/questions/1764809/filesystemwatcher-changed-event-is-raised-twice
    	// so ignore the value if it is empty
    	if (!string.IsNullOrEmpty(line))
    	{
    		// do what you want with the line here
    		Console.WriteLine("last line: " + line);
    	}
}
