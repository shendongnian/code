    public byte[] ToByteArray()
    {
        using(MemoryStream stream = new MemoryStream())
        using(BinaryWriter writer = new BinaryWriter(stream))
        {
            writer.Write(MyInt);
            writer.Write(MyLong);
            writer.Write(Encoding.UTF8.GetBytes(MyString));
            ...
            return stream.ToArray();
        }
    }
