    // allocate memory for string output
    using (MemoryStream MemStream = new MemoryStream(1024))
    {
        xmlSchema.Write(MemStream);
        MemStream.Seek(0, SeekOrigin.Begin);
        using (StreamReader reader = new StreamReader(MemStream))
        {
            SchemaAsString = reader.ReadToEnd();
        }
    }
    return SchemaAsString;
