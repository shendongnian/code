    public static string CreateOutputXmlString(ICollection<Field> fields)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.Encoding = Encoding.GetEncoding("windows-1250");
    
                MemoryStream memStream = new MemoryStream();
                XmlWriter writer = XmlWriter.Create(memStream, settings);
    
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
                writer.Flush();
                writer.Close();
    
                writer.Flush();
                writer.Close();
    
                string xml = Encoding.GetEncoding("windows-1250").GetString(memStream.ToArray());
    
                memStream.Close();
                memStream.Dispose();
    
                return xml;
            }
