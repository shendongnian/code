    public Stream GenerateStreamFromString(string s)
    {
        MemoryStream stream = new MemoryStream();
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
        }
        return stream;
    }
