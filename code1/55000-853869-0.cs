    string xml = "..."; your xml here
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    
    XmlNamespaceManager nsm = new XmlNamespaceManager(new NameTable());
    nsm.AddNamespace("z", "#RowsetSchema");
    
    XmlNode n = doc.DocumentElement
                   .SelectSingleNode("//@ows_AZPersonnummer", nsm);
    Console.WriteLine(n.Value);
