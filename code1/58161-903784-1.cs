    MemoryStream m = new MemoryStream();
    BinaryWriter writer = new BinaryWriter(m);
    writer.Write(true);
    writer.Write("hello");
    writer.Write(12345);
    writer.Flush();
    return m.ToArray();
