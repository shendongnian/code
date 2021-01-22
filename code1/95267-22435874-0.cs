        private void CreateXml()
        {       
            XmlTextWriter xmlwriter = new XmlTextWriter("c:\\test.xml", Encoding.GetEncoding("iso-8859-1"));        
            
            XDocument xdoc = new XDocument(
              new XElement("Test")
            );
            xdoc.Save(xmlwriter);
            xmlwriter.Close();
        }
