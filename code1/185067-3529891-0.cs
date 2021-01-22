    XmlDocument xmlResults = new XmlDocument();
    xmlResults.LoadXml(xml);
    XmlNamespaceManager manager = new XmlNamespaceManager();
    manager.AddNamespace("urn:Microsoft.Search.Response", "ns");
    XmlNodeList results = xmlResults.SelectNodes("//ns:Document", manager);
