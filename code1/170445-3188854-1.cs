    public static byte[] EncryptBytes(byte[] toEncrypt, byte[] key, byte[] IV)
    {
        using (RijndaelManaged RMCrypto = new RijndaelManaged())
        using (MemoryStream ms = new MemoryStream())
        using (ICryptoTransform encryptor = RMCrypto.CreateEncryptor(key, IV))
        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        {
            cs.Write(toEncrypt, 0, toEncrypt.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();
        }
    }
    
    public static byte[] DecryptBytes(byte[] toDecrypt, byte[] key, byte[] IV)
    {
        using (RijndaelManaged RMCrypto = new RijndaelManaged())
        using (MemoryStream ms = new MemoryStream())
        using (ICryptoTransform decryptor = RMCrypto.CreateDecryptor(key, IV))
        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
        {
            cs.Write(toDecrypt, 0, toDecrypt.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();
        }
    }
