    public static T DeepClone<T>(T obj)
    {
        using (var ms = new MemoryStream())
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(ms, obj);
            ms.Position = 0;
            return (T)xs.Deserialize(ms);
        }
    }
