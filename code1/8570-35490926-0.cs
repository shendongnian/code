    var doc = new XDocument(new XDeclaration("1.0", "ISO-8859-1", ""));
            using (XmlWriter writer = doc.CreateWriter()){
                writer.WriteStartDocument();
                writer.WriteStartElement("Root");
                writer.WriteElementString("Foo", "value");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            doc.Save("dte.xml");
