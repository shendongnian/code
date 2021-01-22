        public static void WriteFieldsAsXmlDocument(ICollection<Field> fields, Stream outStream)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.GetEncoding("windows-1250");
            using(XmlWriter writer = XmlWriter.Create(outStream, settings)) {
                writer.WriteStartDocument();
                writer.WriteStartElement("data");
                foreach (Field field in fields)
                {
                    writer.WriteStartElement("item");
                    writer.WriteAttributeString("name", field.Id);
                    writer.WriteAttributeString("value", field.Value);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
