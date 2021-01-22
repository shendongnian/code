    System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry();               
    
    // Push the property values from AD back to cache.
    
    entry.RefreshCache(new string[] {"cn", "www" });
            
