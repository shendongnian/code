    var foo = "foo";
    var formatter = new BinaryFormatter();
    using (var stream = new MemoryStream())
    {
        // Serialize.
        formatter.Serialize(stream, foo);
        
        // Deserialize.
        stream.Seek(0, SeekOrigin.Begin);
        foo = formatter.Deserialize(stream) as string;
    }
