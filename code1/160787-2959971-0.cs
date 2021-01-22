    public static string GetMD5HashFromFile(string filename)
    {
        using (var md5 = new MD5CryptoServiceProvider())
        {
            var buffer = md5.ComputeHash(File.ReadAllBytes(filename));
            var sb = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                sb.Append(buffer[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
