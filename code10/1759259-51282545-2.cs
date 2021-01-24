    public static string Encrypt(string plainText, string key)
    {
        using (var enc = new RijndaelManaged())
        {
            byte[] key2 = Encoding.UTF8.GetBytes(key);
            // Rijndael supports keys of 16, 24, 32 byte long
            Array.Resize(ref key2, key2.Length <= 16 ? 16 : key2.Length <= 24 ? 24 : 32);
            enc.Key = key2; 
            enc.Mode = CipherMode.ECB;
            enc.Padding = PaddingMode.PKCS7;
            using (ICryptoTransform crypt = enc.CreateEncryptor())
            {
                byte[] plain = Encoding.UTF8.GetBytes(plainText);
                byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
                return Convert.ToBase64String(cipher);
            }
        }
    }
