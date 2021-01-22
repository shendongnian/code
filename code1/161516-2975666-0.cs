    public static string EncryptString(string stringToEncrypt, string encryptionKey)
    {
        string encrypted = String.Empty;
        byte[] key = Encoding.Unicode.GetBytes(encryptionKey);
        RijndaelManaged RMCrypto = new RijndaelManaged();
        RMCrypto.Padding = PaddingMode.PKCS7;
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
        byte[] encryptedString = Encoding.ASCII.GetBytes(stringToEncrypt);
        cs.Write(encryptedString, 0, encryptedString.Length);
        cs.FlushFinalBlock();
        cs.Close();
        //encrypted = Encoding.ASCII.GetString(ms.ToArray());
        return Convert.ToBase64String(ms.ToArray());
    }
    public static string DecryptString(string stringToDecrypt, string encryptionKey)
    {
        string decrypted = String.Empty;
        byte[] key = Encoding.Unicode.GetBytes(encryptionKey);
        byte[] data = Convert.FromBase64String(stringToDecrypt);
        RijndaelManaged RMCrypto = new RijndaelManaged();
        RMCrypto.Padding = PaddingMode.PKCS7;
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Write);
        cs.Write(data, 0, data.Length);
        cs.FlushFinalBlock();
        cs.Close();
        decrypted = Encoding.ASCII.GetString(ms.ToArray());
        return decrypted;
    }
