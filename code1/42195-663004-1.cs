    string siteToFind = "Default Web Site";
    
    // The Linq way
    using (DirectoryEntry w3svc1 = new DirectoryEntry("IIS://Localhost/W3SVC"))
    {
    	IEnumerable<DirectoryEntry> children = 
              w3svc1.Children.Cast<DirectoryEntry>();
    
        var sites = 
            from de in children
    	    where
    	     de.SchemaClassName == "IIsWebServer" &&
    	     de.Properties["ServerComment"].Value.ToString() == siteToFind
    	   select de;
        if(sites.Count() > 0)
        {
            // Found matches
        }
    }
    
    // The old way
    using (DirectoryEntry w3svc2 = new DirectoryEntry("IIS://Localhost/W3SVC"))
    {
    
    	foreach (DirectoryEntry de in w3svc2.Children)
    	{
    		if (de.SchemaClassName == "IIsWebServer" && 
    		    de.Properties["ServerComment"].Value.ToString() == siteToFind)
    		{
    			// Found match
    		}
    	}
    }
