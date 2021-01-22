    private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
    	string eventType = e.NewEvent.ClassPath.ClassName;
    	Win32_Process proc = new 
    		Win32_Process(e.NewEvent["TargetInstance"] as ManagementBaseObject);
    
    	switch (eventType)
    	{
    		case "__InstanceCreationEvent":
    			Console.WriteLine("Process Created");
    			break;
    		case "__InstanceDeletionEvent":
    			Console.WriteLine("Process Deleted (Ended)");
    			break;
    		case "__InstanceModificationEvent":
    			Console.WriteLine("Process Modified (possibly still running)");
    			break;
    	}
    }
