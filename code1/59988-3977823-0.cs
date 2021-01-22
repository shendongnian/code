    //Get the data into the XDoc
    XDocument doc = XDocument.Parse(data);
    //Grab the reader
    var reader = doc.CreateReader();
    //Set the root
    var root = doc.Root;
    //Use the reader NameTable
    var namespaceManager = new XmlNamespaceManager(reader.NameTable);
    //Add the GeoRSS NS
    namespaceManager.AddNamespace("georss", "http://www.georss.org/georss");  
    //Do something with it
    Debug.WriteLine(root.XPathSelectElement("//georss:point", namespaceManager).Value);  
