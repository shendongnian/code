     public T XmlDeserialize<T>(string xml)
        {
            var textReader = new XmlTextReader(new StringReader(xml));
            var xmlSerializer = new XmlSerializer(typeof(T), xmlAttributeOverrides); <--this
    
            var result = xmlSerializer.Deserialize(textReader);
            return (T)result;
        }
