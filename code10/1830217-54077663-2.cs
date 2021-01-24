    public string Encrypt(string plainText)
    {
	    // PBKDF2WithHmacSHA256 Key derivation
	    // ...
        using (RijndaelManaged cipher = new RijndaelManaged())
        {
            cipher.Key = secretKey;
            cipher.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            cipher.Mode = CipherMode.CBC;
            cipher.Padding = PaddingMode.PKCS7;
            byte[] encryptedData;
            using (ICryptoTransform encryptor = cipher.CreateEncryptor())
            {
                using (System.IO.MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        encryptedData = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encryptedData);
        }
    }
