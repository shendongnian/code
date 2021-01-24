    public static string CryptString(CryptMethod Method, EncryptionAlgorithms Algorithm, string Value, string Key)
    {
        if (Value == null || Value.Length <= 0)
        {
            throw new ArgumentNullException("Data can not be empty");
        }
        if (Key == null || Key.Length <= 0)
        {
            throw new ArgumentNullException("Key can not be empty");
        }
        SymmetricAlgorithm provider = null;
        try
        {
            switch (Algorithm)
            {
                case EncryptionAlgorithms.Rijndael:
                    provider = new RijndaelManaged();
                    break;
            }
            provider.KeySize = provider.LegalKeySizes[0].MaxSize;
            provider.BlockSize = provider.LegalBlockSizes[0].MaxSize;
            provider.Key = DerivePassword(Key, provider.LegalKeySizes[0].MaxSize / 8);
            switch (provider.BlockSize / 8)
            {
                case 8:
                    provider.IV = IV_8;
                    break;
                case 16:
                    provider.IV = IV_16;
                    break;
                case 24:
                    provider.IV = IV_24;
                    break;
                case 32:
                    provider.IV = IV_32;
                    break;
            }
            if (Method == CryptMethod.Encrypt)
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(Value);
                // Create the streams used for encryption/decryption    
                using (ICryptoTransform encryptor = provider.CreateEncryptor(provider.Key, provider.IV))
                using (var msCrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msCrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(encodedText, 0, encodedText.Length);
                    csEncrypt.FlushFinalBlock();
                    return Convert.ToBase64String(msCrypt.ToArray());
                }
            }
            else
            {
                byte[] cipherBytes = Convert.FromBase64String(Value);
                // Create the streams used for decryption.    
                using (ICryptoTransform decryptor = provider.CreateDecryptor(provider.Key, provider.IV))
                using (var msCrypt = new MemoryStream(cipherBytes))
                using (var csDecrypt = new CryptoStream(msCrypt, decryptor, CryptoStreamMode.Read))
                {
                    byte[] decodedText = new byte[cipherBytes.Length];
                    int decryptedCount = csDecrypt.Read(decodedText, 0, decodedText.Length);
                    return Encoding.Unicode.GetString(decodedText, 0, decryptedCount);
                }
            }
        }
        catch (Exception ex)
        {
            //throw new AceExplorerException(ex.Message + "  " + ex.StackTrace + " " + ex.TargetSite.ToString() + " " + ex.Source, ex.InnerException);
            throw new Exception(ex.Message + "  " + ex.StackTrace + " " + ex.TargetSite.ToString() + " " + ex.Source, ex.InnerException);
        }
        finally
        {
            // Clear the Provider object.    
            provider?.Clear();
        }
    }
    #endregion
    private static byte[] DerivePassword(string password, int length)
    {
        Rfc2898DeriveBytes derivedBytes = new Rfc2898DeriveBytes(password, CRYPT_SALT, 1000);
        return derivedBytes.GetBytes(length);
    }
