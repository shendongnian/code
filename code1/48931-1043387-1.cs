    private byte[] ObjectToByteArray(Object obj)
    {
        if (obj == null)
        {
            return null;
        }
        
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, obj);
        return ms.ToArray();
    }
