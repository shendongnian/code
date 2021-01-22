    ....
    byte[] data;
    using (var stream = assembly.GetManifestResourceStream(filename))
    {
        var length = stream.Length;
        data = new byte[length];
        stream.Read(data, 0, (int) length);
    }
    if (!HasUtf8ByteOrderMark(data))
    {
        throw new InvalidOperationException("Expected UTF8 byte order mark EF BB BF");
    }
    return Encoding.UTF8.GetChars(data.Skip(3).ToArray());
