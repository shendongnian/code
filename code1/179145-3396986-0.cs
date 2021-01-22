    public static object CloneObject(object obj)
    {
        using (MemoryStream memStream = new MemoryStream())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter(null, 
                 new StreamingContext(StreamingContextStates.Clone));
            binaryFormatter.Serialize(memStream, obj);
            memStream.Seek(0, SeekOrigin.Begin);
            return binaryFormatter.Deserialize(memStream);
        }
    }
