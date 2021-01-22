    static public T DeepCopy<T>(T obj)
    {
        BinaryFormatter s = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            s.Serialize(ms, obj);
            ms.Position = 0;
            T t = (T)s.Deserialize(ms);
            return t;
        }
    }
