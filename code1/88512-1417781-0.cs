            XDocument doc = new XDocument();
            doc.AddFirst(new XDocumentType("html", null, null, null));
            doc.Add(new XElement("foo", "bar"));
            using (XmlTextWriter writer = new XmlTextWriter("c:\\temp\\no_space.xml", null)) {
                writer.Formatting = Formatting.Indented;
                doc.WriteTo(writer);
                writer.Flush();
                writer.Close();
            }
