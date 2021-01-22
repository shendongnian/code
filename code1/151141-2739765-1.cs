    public static byte[] Compress(byte[] uncompressed)
    {
        using (MemoryStream ms = new MemoryStream())
        using (GZipStream gzs = new GZipStream(ms, CompressionMode.Compress))
        {
            gzs.Write(uncompressed, 0, uncompressed.Length);
            gzs.Close();
            return ms.ToArray();
        }
    }
    public static byte[] Decompress(byte[] compressed)
    {
        byte[] buffer = new byte[4096];
        using (MemoryStream ms = new MemoryStream(compressed))
        using (GZipStream gzs = new GZipStream(ms, CompressionMode.Decompress))
        using (MemoryStream uncompressed = new MemoryStream())
        {
            for (int r = -1; r != 0; r = gzs.Read(buffer, 0, buffer.Length))
                if (r > 0) uncompressed.Write(buffer, 0, r);
            return uncompressed.ToArray();
        }
    }
