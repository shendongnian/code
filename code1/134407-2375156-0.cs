    XmlReaderSettings xrs = new XmlReaderSettings();
    xrs.ConformanceLevel = ConformanceLevel.Fragment;
    XDocument doc = new XDocument(new XElement("root"));
    XElement root = doc.Descendants().First();
    using (StreamReader fs = new StreamReader("XmlFile1.xml"))
    using (XmlReader xr = XmlReader.Create(fs, xrs))
    {
        while(xr.Read())
        {
            if (xr.NodeType == XmlNodeType.Element)
            {
                root.Add(XElement.Load(xr.ReadSubtree()));                
            }
        }
    }
