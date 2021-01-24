        private void button2_Click(object sender, EventArgs e)
        {
            List<string> objdec = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\Stephen\Documents\Schema\AgileFlow_Import.xsd");
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
            XmlNodeList nodes = xmlDoc.SelectNodes("//xs:element[@name='IR_DocumentMaster']//xs:complexType//xs:all//xs:element", nsmgr);
            try
            {
                objdec = nodes.Cast<XmlNode>().Where(node =>  node.Attributes.GetNamedItem("minOccurs") != null && node.Attributes.GetNamedItem("minOccurs").Value == "0")
                               .Select(x => x.Attributes["name"].Value).ToList();
 
 
