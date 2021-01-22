    XmlSerializer xs = new XmlSerializer(pObject.GetType());
    using (MemoryStream memoryStream = new MemoryStream())
    {
        XmlWriterSettings settings = new XmlWriterSettings()
        {
            Encoding = Encoding.UTF8
        };
        using (XmlWriter writer = XmlWriter.Create(memoryStream, settings))
        {
            xs.Serialize(writer, pObject);
        }
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }
