    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(new System.IO.StringReader(xmlText));
    XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
    manager.AddNamespace("ns", 
        "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
    foreach (XmlNode node in xmlDoc.SelectNodes("//ns:Template", manager))
    {
        Console.WriteLine("{0}: {1}", node.Name, node.InnerText);
    }
