    using (var stream = new MemoryStream())
    { 
        var serializer = new DataContractSerializer(objectInstance.GetType());
        serializer.WriteObject(stream, objectInstance);
    
        // The object has now been serialized to the stream
        // Do something with the stream here.
    }
