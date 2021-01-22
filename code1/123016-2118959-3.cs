    public static byte[] ZipStr(String str)
    {
        using (MemoryStream output = new MemoryStream())
        {
            using (DeflateStream gzip = 
              new DeflateStream(output, CompressionMode.Compress))
            {
                using (StreamWriter writer = 
                  new StreamWriter(gzip, System.Text.Encoding.UTF8))
                {
                    writer.Write(str);           
                }
            }
            return output.ToArray();
        }
    }
    public static string UnZipStr(byte[] input)
    {
        using (MemoryStream inputStream = new MemoryStream(input))
        {
            using (DeflateStream gzip = 
              new DeflateStream(inputStream, CompressionMode.Decompress))
            {
                using (StreamReader reader = 
                  new StreamReader(gzip, System.Text.Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
