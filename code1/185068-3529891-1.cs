    XmlDocument xmlResults = new XmlDocument();
    xmlResults.LoadXml(xml);
    XmlNamespaceManager manager = new XmlNamespaceManager(xmlResults.NameTable);
    manager.AddNamespace("ns", "urn:Microsoft.Search.Response.Document");
    XmlNodeList results = xmlResults.SelectNodes("//ns:Document", manager);
