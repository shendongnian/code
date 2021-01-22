    string appPoolpath = "IIS://localhost/W3SVC/AppPools/MyAppPool";
    using(DirectoryEntry appPool = new DirectoryEntry(appPoolPath))
    {
    	using(DirectoryEntry w3svc = 
                   new DirectoryEntry(@"IIS://Localhost/W3SVC/AppPools"))
    	{
    		w3svc.Children.Remove(appPool);
    		w3svc.CommitChanges();
    	}
    }
