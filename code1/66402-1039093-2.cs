    // Call me using: string doc = GetDefaultDocument("/");
    public string GetDefaultDocument(string serverPath)
    {
    	using (DirectoryEntry w3svc =
    		 new DirectoryEntry("IIS://Localhost/W3SVC/1/root"))
    	{
    		string[] defaultDocs =
    			w3svc.Properties["DefaultDoc"].Value.ToString().Split(',');
    
    		string path = Server.MapPath(serverPath);
    
    		foreach (string docName in defaultDocs)
    		{
    			if(File.Exists(Path.Combine(path, docName)))
    			{
    				Console.WriteLine("Default Doc is: " + docName);
    				return docName;
    			}
    		}
    		// No matching default document found
    		return null;
    	}
    }
