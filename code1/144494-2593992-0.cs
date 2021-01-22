    public void countItems(string fileName)
    {
        XmlDocument document = new XmlDocument();
        document.Load(fileName);
        XmlNode root = document.DocumentElement;
	
        // create ns manager
        XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(document.NameTable);
        xmlnsManager.AddNamespace("def", "http://schemas.microsoft.com/collection/metadata/2009");
        // use ns manager
        XmlNodeList xnl = root.SelectNodes("//def:Item", xmlnsManager);
        Response.Write(String.Format("Found {0} items" , xnl.Count));
    }
