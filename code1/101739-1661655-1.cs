    public static void GetPublicFolderList()
    {
    	DirectoryEntry entry = new DirectoryEntry("LDAP://FakeDomain.com");
    	DirectorySearcher mySearcher = new DirectorySearcher(entry);
    	mySearcher.Filter = "(&(objectClass=publicfolder))";
    	mySearcher.SizeLimit = int.MaxValue;
    	mySearcher.PageSize = int.MaxValue;            
    
    	foreach (SearchResult resEnt in mySearcher.FindAll())
    	{
    		if (resEnt.Properties.Count == 1)
    			continue;
    
    		object OO = resEnt.Properties["mail"][0];
    	}
    }
