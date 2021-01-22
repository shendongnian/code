    public T DeserializeXml<T>(XDocument document)
    {
        using (var reader = document.CreateReader())
        {
            var serializer = new XmlSerializer(typeof (T));
            return (T) serializer.Deserialize(reader);
        }
    }
