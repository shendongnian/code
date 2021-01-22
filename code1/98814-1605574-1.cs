    public static List<string> GetComputers()
    {
    	List<string> ComputerNames = new List<string>();
    
    	DirectoryEntry entry = new DirectoryEntry("LDAP://YourActiveDirectoryDomain.no");
        DirectorySearcher mySearcher = new DirectorySearcher(entry);
        mySearcher.Filter = ("(objectClass=computer)");
        mySearcher.SizeLimit = int.MaxValue;
        mySearcher.PageSize = int.MaxValue;
                            
        foreach(SearchResult resEnt in mySearcher.FindAll())
        {
    		//"CN=SGSVG007DC"
    		string ComputerName = resEnt.GetDirectoryEntry().Name;
    		if (ComputerName.StartsWith("CN="))
    			ComputerName = ComputerName.Remove(0,"CN=".Length);
            ComputerNames.Add(ComputerName);
        }
    
    	mySearcher.Dispose();
    	entry.Dispose();
    
        return ComputerNames;
    }
