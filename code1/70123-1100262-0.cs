        public static void TestXPath()
        {
            string xmlText = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>";
            xmlText += "<Properties xmlns=\"http://schemas.openxmlformats.org/officeDocument/2006/extended-properties\" xmlns:vt=\"http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes\">";
            xmlText += "<Template>Normal</Template>  <TotalTime>1</TotalTime>  <Pages>1</Pages>  <Words>6</Words>";
            xmlText += "</Properties>";
    
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new System.IO.StringReader(xmlText));
            
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("res", "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
    
            foreach (XmlNode node in xmlDoc.SelectNodes("//res:Template", nsmgr))
            {
                Console.WriteLine("{0}: {1}", node.Name, node.InnerText);
            }
        }
