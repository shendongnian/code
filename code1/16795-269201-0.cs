    MemoryStream mem = new MemoryStream(_array);
    
    
    float ReadFloat(Stream str)
    {
       byte[] bytes = str.Read(out bytes, 0, 4);
       return BitConverter.ToSingle(bytes, 0)
    }
    public int ReadInt32(Stream str)
    {
       byte[] bytes = str.Read(out bytes, 0, 4);
       return BitConverter.ToInt32(bytes, 0)
    }
