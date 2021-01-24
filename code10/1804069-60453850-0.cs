    public static string CalculateContentMD5(Stream stream)
    {
        stream.Position = 0;
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] hash = provider.ComputeHash(content);
        return Convert.ToBase64String(hash);
    }
