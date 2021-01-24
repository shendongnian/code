    FileSystemWatcher fileWatcher;
       
    private void watch()
    {
    	fileWatcher = new FileSystemWatcher();
    	fileWatcher.Path = path;
    	fileWatcher.Created += new FileSystemEventHandler(OnCreated);
    	fileWatcher.EnableRaisingEvents = true;
    }
    private void OnCreated(object source, FileSystemEventArgs e)
    {
    	WaitForFile(e.FullPath);
    		
    	//Copy files to another directory.
    }
    private void WaitForFile(string fullPath)
    {
    	while (true)
    	{
    		try
    		{
    			using (StreamReader stream = new StreamReader(fullPath))
    			{
    				break;
    			}
    		}
    		catch
    		{
    			Thread.Sleep(1000);
    		}
    	}
    }
