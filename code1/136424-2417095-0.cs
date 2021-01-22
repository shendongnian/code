    public static object CloneObject(object obj)
    {
        using (var memStream = new MemoryStream())
        {
            var binaryFormatter = new BinaryFormatter(
                 null, 
                 new StreamingContext(StreamingContextStates.Clone));
            binaryFormatter.Serialize(memStream, obj);
            memStream.Seek(0, SeekOrigin.Begin);
            return binaryFormatter.Deserialize(memStream);
        }
    }
