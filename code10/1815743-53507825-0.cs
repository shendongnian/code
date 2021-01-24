    string Encrypt(string toEncrypt)
    {
        byte[] key = ...
        byte[] iv = ...
        using (AesCng aes = new AesCng())
        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, iv))
        using (MemoryStream memStream = new MemoryStream())
        using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write,true))
        {
            UTF7Encoding encoder = new UTF7Encoding();
            byte[] bytes = encoder.GetBytes(toEncrypt);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            return Convert.ToBase64String(memStream.ToArray());
        }
    }
