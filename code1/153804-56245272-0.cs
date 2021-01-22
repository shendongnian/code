    private byte[] CompressWithLevels(byte[] data)
    {
        using(MemoryStream ms = new MemoryStream())
        {
            using(GZipStream gz = new GZipStream(ms, CompressionMode.Compress))
            {
                gz.Write(data, 0, data.Length);
                return ms.ToArray();
            }
        }
    }
