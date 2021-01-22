      public static readonly UnicodeEncoding ByteConverter = new UnicodeEncoding();
      public static string Encrypt(string textToEncrypt, out string publicKey,
        out string privateKey)
      {
         byte[] bytesToEncrypt = ByteConverter.GetBytes(textToEncrypt);
         byte[] encryptedBytes;
         using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
         {
            encryptedBytes = rsa.Encrypt(bytesToEncrypt, false);
            publicKey = rsa.ToXmlString(false);
            privateKey = rsa.ToXmlString(true);
         }
         return Convert.ToBase64String(encryptedBytes);
      }
      public static string Decrypt(string textToDecrypt, string privateKeyXml)
      {
         if (string.IsNullOrEmpty(textToDecrypt))
         {
            throw new ArgumentException(
                "Cannot decrypt null or blank string"
            );
         }
         if (string.IsNullOrEmpty(privateKeyXml))
         {
            throw new ArgumentException("Invalid private key XML given");
         }
         byte[] bytesToDecrypt = Convert.FromBase64String(textToDecrypt);
         byte[] decryptedBytes;
         using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
         {
            rsa.FromXmlString(privateKeyXml);
            decryptedBytes = rsa.Decrypt(bytesToDecrypt, false); // fail here
         }
         return ByteConverter.GetString(decryptedBytes);
      }
