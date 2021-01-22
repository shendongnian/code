    private static object GetCopy(object input)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, input);
            stream.Position = 0;
            return formatter.Deserialize(stream);
        }
    }
