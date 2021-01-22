    public object Clone(object toClone)
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms= new MemoryStream();
        bf.Serialize(ms, toClone);
        ms.Flush();
        ms.Position = 0;
        return bf.Deserialize(ms);
    }
    
