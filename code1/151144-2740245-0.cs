    public static string Decompress(byte[] gzBuffer)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length – 4);
            byte[] buffer = new byte[msgLength];
            ms.Position = 0;
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
            {
                zip.Read(buffer, 0, buffer.Length);
            }
            return Encoding.UTF8.GetString(buffer);
        } 
    }  
