    public byte[] ConvertObjectToByteArray(object source)
    {
        var formatter = new BinaryFormatter();
        using (var memoryStream = new MemoryStream())
        {
            formatter.Serialize(memoryStream, source);                
            return memoryStream.ToArray();
        }
    }
