    string metabasePath = "IIS://" + server.ComputerName + "/W3SVC";
    DirectoryEntry w3svc = new DirectoryEntry(metabasePath, server.Username, server.Password);
    
    string serverBindings = ":80:" + site.HostName;
    string homeDirectory = server.WWWRootPath + "\\" + site.FolderName;
    
    
    object[] newSite = new object[] { site.Name, new object[] { serverBindings }, homeDirectory };
    
    object websiteId = (object)w3svc.Invoke("CreateNewSite", newSite);
    
    // Returns the Website ID from the Metabase
    int id = (int)websiteId;
