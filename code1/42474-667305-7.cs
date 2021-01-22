    string appPoolPath = "IIS://Localhost/W3SVC/AppPools/MyAppPool";
    using(DirectoryEntry appPool = new DirectoryEntry(appPoolPath))
    {
    	using(DirectoryEntry parent = appPool.Parent)
    	{
    		parent.Children.Remove(appPool);
    		parent.CommitChanges();
    	}
    }
