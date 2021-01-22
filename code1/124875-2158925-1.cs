    public static string SqlXmlFromZippedBytes(byte[] input)
    {
        if (input == null){
            return null;
        }
        using (MemoryStream inputStream = new MemoryStream(input))
        using (DeflateStream gzip = new DeflateStream(inputStream, CompressionMode.Decompress))
        using (StreamReader reader = new StreamReader(gzip, System.Text.Encoding.UTF8))
        {
            return new SqlXml(reader); // From System.Data.SqlTypes
        }
    }
