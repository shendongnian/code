            XDocument doc = new XDocument(
                new XComment("This is a comment"),
                new XElement("Root",
                    new XElement("Child1", "data1"),
                    new XElement("Child2", "data2")
                )
            );
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlextWriter.Create(sb, settings);
            doc.WriteTo(writer);
            writer.Flush();
            string outputXml = sb.ToString();
