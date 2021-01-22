    string appPoolpath = "IIS://Localhost/W3SVC/AppPools/MyAppPool";
    using(DirectoryEntry appPool = new DirectoryEntry(appPoolPath))
    {
    	using(DirectoryEntry appPools = 
                   new DirectoryEntry(@"IIS://Localhost/W3SVC/AppPools"))
    	{
    		appPools.Children.Remove(appPool);
    		appPools.CommitChanges();
    	}
    }
