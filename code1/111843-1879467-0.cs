    private Stream GenerateStreamFromString(String p)
    {
        Byte[] bytes = UTF8Encoding.GetBytes(p);
        MemoryStream strm = new MemoryStream();
        strm.Write(bytes, 0, bytes.Length);
        return strm;
    }
