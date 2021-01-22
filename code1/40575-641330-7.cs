    private XmlNamespaceManager _nsm = 
			new XmlNamespaceManager(new NameTable());
    private XmlDocument _doc = new XmlDocument();
    _doc.Load(@"c:\windows\system32\inetsrv\metabase.xml");
    _nsm.AddNamespace("iis", "urn:microsoft-catalog:XML_Metabase_V64_0");
    
    // lmPath could be build from the DirectoryEntry.Path property
    string lmPath = "/lm/w3svc/1/root/myapp";
    
    // Try as an IIsWebDirectory object
    string iisWebDirectoryXPath = 
    	String.Format(@"//iis:IIsWebDirectory[translate(@Location, 
    			'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 
    			'abcdefghijklmnopqrstuvwxyz') = '{0}']",
    			lmPath);
    						
    mbNode = _doc.DocumentElement.SelectSingleNode(iisWebDirectoryXPath, _nsm);
    
    if(mbNode != null)
    {
    	// We found an IIsWebDirectory - is it an application though?
    	if (mbNode.Attributes["AppIsolated"] != null)
    	{
    		// IIsWebDirectory is an Application
    	}
    }
    else
    {
    	// Is our object an IIsWebVirtualDir?
    	string iisWebVirtualDirectoryXPath = 
    		String.Format(@"//iis:IIsWebVirtualDir[translate(@Location, 
    				'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 
    				'abcdefghijklmnopqrstuvwxyz') = '{0}']",
    				lmPath);
    							
    	mbNode = _doc.DocumentElement
    			.SelectSingleNode(iisWebVirtualDirectoryXPath, _nsm);
    
    	if (mbNode != null)
    	{
    		// Yes it's an IIsWebVirtualDir
    		if (mbNode.Attributes["Path"] != null)
    		{
    			if(mbNode.Attributes["AppIsolated"] != null)
    			{
    				// And it's an application
    			}
    		}
    	}
    }
