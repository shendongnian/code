    public static void OnChangedOnce(this FileSystemWatcher instance, Action<object, FileSystemEventArgs> action)
    {
    	var file = instance;
    	var wrappedAction = action;
    	FileSystemEventHandler handler = null;
    	handler = (object sender, FileSystemEventArgs args) =>
    	{
    		wrappedAction(sender, args);
    		file.Changed -= handler;
    	};
    	file.Changed += handler;
    	file.EnableRaisingEvents = true; // mandatory
    }
	
	var file = new FileSystemWatcher("path/to/file");
	file.OnChangedOnce((sender, args)) =>
	{
		// your action here
	});
