    public T ConvertXml<T>(string xml)
    {
        using (var serializer = new XmlSerializer(typeof(T)))
        {
            return (T)serializer.Deserialize(xml);
        }
    }
