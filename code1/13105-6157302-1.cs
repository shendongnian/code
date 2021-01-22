     private static string Encrypt(string plainStr, string KeyString)        
        {            
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.ECB;
            aesEncryption.Padding = PaddingMode.ISO10126;
            byte[] KeyInBytes = Encoding.UTF8.GetBytes(KeyString);
            aesEncryption.Key = KeyInBytes;
            byte[] plainText = ASCIIEncoding.UTF8.GetBytes(plainStr);
            ICryptoTransform crypto = aesEncryption.CreateEncryptor();
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }
     private static string Decrypt(string encryptedText, string KeyString) 
        {
            RijndaelManaged aesEncryption = new RijndaelManaged(); 
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128; 
            aesEncryption.Mode = CipherMode.ECB;
            aesEncryption.Padding = PaddingMode.ISO10126;
            byte[] KeyInBytes = Encoding.UTF8.GetBytes(KeyString);
            aesEncryption.Key = KeyInBytes;
            ICryptoTransform decrypto = aesEncryption.CreateDecryptor(); 
            byte[] encryptedBytes = Convert.FromBase64CharArray(encryptedText.ToCharArray(), 0, encryptedText.Length); 
            return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length)); 
        }
