    //Instantiate an XmlDocument object.
    XmlDocument xmldoc = new XmlDocument();
    
    //Load XML file into the XmlDocument object. 
    xmldoc.Load("C:\\myFile.xml");
    
    //Instantiate an XmlNamespaceManager object. 
    XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmldoc.NameTable);
    
    // Retrieve the namespaces into a Generic dictionary with string keys.
    IDictionary<string, string> dic = nsMgr.GetNamespacesInScope(XmlNamespaceScope.All);
    
    // Iterate through the dictionary.
    
    ...
