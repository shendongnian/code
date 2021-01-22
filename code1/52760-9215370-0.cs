    public static string MD5Hash(string text)
    {
        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(md5.ComputeHash(ASCIIEncoding.Default.GetBytes(text))), “-”, “”);
    }
