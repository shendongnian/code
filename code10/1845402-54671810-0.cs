    if (valueType != null)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(valueType);
        using (MemoryStream stream = new MemoryStream())
        {
            xmlSerializer.Serialize(stream, entry.Value);
            stream.Position = 0;
                            
            using (XmlReader reader = XmlReader.Create(stream))
            {
                XElement valueXml = XElement.Load(reader);
                value = valueXml;
            }
        }
    }
