    public static string Encrypt(string toEncrypt, string algorithmName)
    {
        byte[] bytePlain = System.Text.Encoding.UTF8.GetBytes ( strPlainTxt );
        using (HashAlgorithm algorithm = HashAlgorithm.Create(algorithm))
        {
            byte[] byteHash = algorithm.ComputeHash(bytePlain);
            string strHashedTxt = Convert.ToBase64String (byteHash);
            return strHashedTxt;
        }
    }
