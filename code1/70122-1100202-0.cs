    XmlNamespaceManager mgr = new XmlNamespaceManager(xmlDoc.NameTable);
    mgr.AddNamespace("x",
        "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
    foreach (XmlNode node in xmlDoc.SelectNodes("//x:Template", mgr))
    {
        Console.WriteLine("{0}: {1}", node.Name, node.InnerText);
    }
