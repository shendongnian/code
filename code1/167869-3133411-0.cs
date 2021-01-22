    private static string GetContents(TransactionResults t)
    {
        XmlSerializer s = new XmlSerializer(typeof(TransactionResults));
        MemoryStream stream = new MemoryStream();
        s.Serialize(stream, t);
        stream.Position = 0; // Rewind to the beginning of the stream
        return new StreamReader(stream).ReadToEnd();
    }
