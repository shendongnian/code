    XmlDocument doc = new XmlDocument();
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
    nsmgr.AddNamespace("sample", "...");
    doc.Load(stream);
    XmlNode topic = doc.SelectSingleNode("/sample:topic", nsmgr);
    // If you don't have any namespaces....
    XmlNode topic2 = doc.SelectSingleNode("/topic"); 
