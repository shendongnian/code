    var xmlDoc = new XmlDocument();
    // content is your XML as string
    xmlDoc.LoadXml(content);
	XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
	
	// make sure the namespace identifier, URN in this case, matches what you have in your XML 
    nsmgr.AddNamespace("ns", "urn:oasis:names:tc:SAML:2.0:protocol");
    
	// get the value of Destination attribute from within the Response node with a prefix who's identifier is "urn:oasis:names:tc:SAML:2.0:protocol" using XPath
	var str = xmlDoc.SelectSingleNode("/ns:Response/@Destination", nsmgr);
	if (str != null)
    {
		Console.WriteLine(str.Value);
	}
