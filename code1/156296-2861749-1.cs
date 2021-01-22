    public static object DeserializeObject(string str)
    {
        object result = null;
        byte[] bytes = Convert.FromBase64String(str);
        using (MemoryStream stream = new MemoryStream(bytes))
        {
            BinaryFormatter bf = new BinaryFormatter();
            result = bf.Deserialize(stream);
        }
        return result;
    }
