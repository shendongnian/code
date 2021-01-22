    private string Serialize<T>(T value)
            {
                if (value == null)
                {
                    return string.Empty;
                }
                try
                {
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
                    StringWriter stringWriter = new StringWriter();
                    XmlWriter writer = XmlWriter.Create(stringWriter);
                    xmlserializer.Serialize(writer, value);
                    string serializeXml = stringWriter.ToString();
                    writer.Close();               
                    return serializeXml;
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }
