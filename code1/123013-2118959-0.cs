    public static string UnZipStr(byte[] input)
    {
        using (MemoryStream inputStream = new MemoryStream(input))
        using (DeflateStream gzip = 
          new DeflateStream(inputStream, CompressionMode.Decompress))
        using (StreamReader reader = 
          new StreamReader(gzip, System.Text.Encoding.UTF8))
        {
            return reader.ReadToEnd();
        }
    }
