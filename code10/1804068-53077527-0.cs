     public static string CalculateContentMD5(byte[] content)
     {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] hash = provider.ComputeHash(content);
            return Convert.ToBase64String(hash);
     }
