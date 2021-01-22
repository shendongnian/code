    public static byte[] EncryptString(string stringToEncrypt, string encryptionKey)
    {
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] key = UE.GetBytes(encryptionKey);
        using (RijndaelManaged RMCrypto = new RijndaelManaged())
        using (MemoryStream ms = new MemoryStream())
        using (ICryptoTransform encryptor = RMCrypto.CreateEncryptor(key, key))
        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        {
            byte[] encryptedString = UE.GetBytes(stringToEncrypt);
            cs.Write(encryptedString, 0, encryptedString.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();
        }
    }
    public static string DecryptString(byte[] stringToDecrypt, string encryptionKey)
    {
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] key = UE.GetBytes(encryptionKey);
        using (RijndaelManaged RMCrypto = new RijndaelManaged())
        using (MemoryStream ms = new MemoryStream())
        using (ICryptoTransform decryptor = RMCrypto.CreateDecryptor(key, key))
        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
        {
            cs.Write(stringToDecrypt, 0, stringToDecrypt.Length);
            cs.FlushFinalBlock();
            return UE.GetString(ms.ToArray());
        }
    }
