    public static T Clone<T>(this T source)
    {
        if(Attribute.GetCustomAttribute(typeof(T), typeof(ProtoBuf.ProtoContractAttribute))
               == null)
        {
            throw new ArgumentException("Type has no ProtoContract!", "source");
        }
        if(Object.ReferenceEquals(source, null))
        {
            return default(T);
        }
        IFormatter formatter = ProtoBuf.Serializer.CreateFormatter<T>();
        using (Stream stream = new MemoryStream())
        {
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }
