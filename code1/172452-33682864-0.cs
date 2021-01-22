    var serializer = new DataContractSerializer(typeof(T));
    var sb = new StringBuilder();
    using (var writer = XmlWriter.Create(sb))
    {
        serializer.WriteObject(writer, objectToSerialize);
    }
    
    return sb.ToString();
