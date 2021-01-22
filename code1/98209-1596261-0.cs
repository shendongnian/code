    public static string Decrypt(string inputText)
          {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] encryptedData = Convert.FromBase64String(inputText.Replace(" ","+"));
            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);
        
            using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
              using (MemoryStream memoryStream = new MemoryStream(encryptedData))
              {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                  byte[] plainText = new byte[encryptedData.Length];
                  int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                  return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                }
              }
            }
