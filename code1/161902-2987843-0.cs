    public static string encryptPasswordWithMd5(string password)
    {
        var md5 = new MD5CryptoServiceProvider();
        var originalBytes = ASCIIEncoding.Default.GetBytes(password);
        var encodedBytes = md5.ComputeHash(originalBytes);
        return BitConverter.ToString(encodedBytes);
    }
