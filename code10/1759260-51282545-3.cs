    public static string Decrypt(string cipherText, string key)
    {
        using (var enc = new RijndaelManaged())
        {
            byte[] key2 = Encoding.UTF8.GetBytes(key);
            // Rijndael supports keys of 16, 24, 32 byte long
            Array.Resize(ref key2, key2.Length <= 16 ? 16 : key2.Length <= 24 ? 24 : 32);
            enc.Key = key2;
            enc.Mode = CipherMode.ECB;
            enc.Padding = PaddingMode.PKCS7;
            using (ICryptoTransform crypt = enc.CreateDecryptor())
            {
                byte[] cipher = Convert.FromBase64String(cipherText);
                byte[] plain = crypt.TransformFinalBlock(cipher, 0, cipher.Length);
                return Encoding.UTF8.GetString(plain);
            }
        }
    }
