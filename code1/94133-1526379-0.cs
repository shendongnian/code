    XmlDocument doc = new XmlDocument();
            doc.Load(@"F:\xml\sample.xml");
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("sam", "http://tempuri.org/DataSchema.xsd");
            XmlNode node = doc.SelectSingleNode(
                "/sam:DataSchema/sam:ManagedObject/sam:version", nsmgr);
            string version = node == null ? null : node.InnerText;
    
            _listview.Items.Add(version);
