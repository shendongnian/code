    public static object DeserializeObject(string str)
    {
        byte[] bytes = Convert.FromBase64String(str);
        using (MemoryStream stream = new MemoryStream(bytes))
        {
            return new BinaryFormatter().Deserialize(stream);
        }
    }
