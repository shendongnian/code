        XmlDocument d = new XmlDocument();
        d.LoadXml(xml);
        XmlNamespaceManager ns = new XmlNamespaceManager(d.NameTable);
        ns.AddNamespace("n", "http://www.w3.org/XML/1998/namespace");
        foreach (XmlNode n in d.SelectNodes("/root/Table/n:LOCATION", ns))
        {
            XmlElement loc = d.CreateElement("LOCATION");
            n.ParentNode.AppendChild(loc);
            n.ParentNode.RemoveChild(n);
        }
        DataSet ds = new DataSet();
        using (StringReader sr = new StringReader(d.OuterXml))
        {
            ds.ReadXml(sr);
        }
