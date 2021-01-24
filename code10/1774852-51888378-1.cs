    #region "String Encryption"
    public static string EncryptString(EncryptionAlgorithms Method, string Value, string Key)
    {
        return CryptString(CryptMethod.Encrypt, Method, Value, Key);
    }
    public static string DecryptString(EncryptionAlgorithms Method, string Value, string Key)
    {
        return CryptString(CryptMethod.Decrypt, Method, Value, Key);
    }
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
                ICryptoTransform ICrypt = provider.CreateEncryptor(provider.Key, provider.IV);
                byte[] EncodedText = Encoding.Unicode.GetBytes(Value);
                // Create the streams used for encryption/decryption    
                using (MemoryStream msCrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msCrypt, ICrypt, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(EncodedText, 0, EncodedText.Length);
                    csEncrypt.FlushFinalBlock();
                    return Convert.ToBase64String(msCrypt.ToArray());
                }
            }
            else
            {
                byte[] cipherBytes = Convert.FromBase64String(Value);
                ICryptoTransform ICrypt = provider.CreateDecryptor(provider.Key, provider.IV);
                // Create the streams used for decryption.    
                using (MemoryStream msCrypt = new MemoryStream(cipherBytes))
                using (CryptoStream csDecrypt = new CryptoStream(msCrypt, ICrypt, CryptoStreamMode.Read))
                {
                    byte[] DecodedText = new byte[cipherBytes.Length];
                    int decryptedCount = csDecrypt.Read(DecodedText, 0, DecodedText.Length);
                    return Encoding.Unicode.GetString(DecodedText, 0, decryptedCount);
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
            if ((provider != null))
            {
                provider.Clear();
            }
        }
    }
    #endregion
    private static byte[] DerivePassword(string Password, int Length)
    {
        Rfc2898DeriveBytes derivedBytes = new Rfc2898DeriveBytes(Password, CRYPT_SALT, 5);
        return derivedBytes.GetBytes(Length);
    }
