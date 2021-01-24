    var stream;
    using (MemoryStream ms = new MemoryStream())
    {
        stream.CopyTo(ms);
        client.Upload(new ByteArrayPart(stream.ToArray(), fileName));
    }
