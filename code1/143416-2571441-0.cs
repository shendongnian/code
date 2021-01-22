    var list = new List<Instance>();
    ...
    
    // Serialization
    
    var xs = new XmlSerializer(typeof(List<Instance>));
    using (var writer = XmlWriter.Create(filename))
    {
        xs.Serialize(writer, list);
    }
    
    ...
    
    // Deserialization
    
    using (var reader = XmlReader.Create(filename))
    {
        list = xs.Deserialize(reader) as List<Instance>;
    }
