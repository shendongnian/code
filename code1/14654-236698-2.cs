    public static Stream Serialize(object source)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        formatter.Serialize(stream, source);
        return stream;
    }
    public static T Deserialize<T>(Stream stream)
    {
        IFormatter formatter = new BinaryFormatter();
        stream.Position = 0;
        return (T)formatter.Deserialize(stream);
    }
    public static T Clone<T>(object source)
    {
        return Deserialize<T>(Serialize(source));
    }
