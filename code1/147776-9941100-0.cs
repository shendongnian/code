    public System.IO.Stream CreateStream(string value)
    {
        var baseStream = new System.IO.MemoryStream();
        var baseCopy = new System.IO.MemoryStream();
        using (var writer = new System.IO.StreamWriter(baseStream, System.Text.Encoding.UTF8))
        {
            writer.Write(value);
            writer.Flush();
            baseStream.WriteTo(baseCopy); 
        }
        var returnStream = new System.IO.MemoryStream( baseCopy.ToArray());
        return returnStream;
    }
