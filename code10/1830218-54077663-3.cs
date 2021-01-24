    public string Decrypt(string encryptedText)
    {
	    // PBKDF2WithHmacSHA256 Key derivation
	    // ...
        using (RijndaelManaged cipher = new RijndaelManaged())
        {
            cipher.Key = secretKey;
            cipher.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            cipher.Mode = CipherMode.CBC;
            cipher.Padding = PaddingMode.PKCS7;
            string decryptedText;
            using (ICryptoTransform decryptor = cipher.CreateDecryptor())
            {
                using (System.IO.MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            decryptedText = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return decryptedText;
        }
    }
