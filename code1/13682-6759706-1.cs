    public static T DeepClone<T>(T obj)
    {
        T objResult;
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            ms.Position = 0;
            objResult = (T)bf.Deserialize(ms);
        }
        return objResult;
    }
