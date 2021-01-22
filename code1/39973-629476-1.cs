    // deep copy in separeate memory space
    public object Clone()
    {
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(ms, this);
        ms.Position = 0;
        object obj = bf.Deserialize(ms);
        ms.Close();
        return obj;
    }
