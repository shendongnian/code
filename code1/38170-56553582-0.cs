        public static byte[] Encrypt(byte[] buffer, byte[] sessionKey, out byte[] iv)
        {
            byte[] encrypted;
            iv = null;
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
            {
                aesAlg.Key = sessionKey;
                iv = aesAlg.IV;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(sessionKey, iv);
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(buffer, 0, buffer.Length);
                        
                        //This was not closing the cryptostream and only worked if I called FlushFinalBlock()
                        //encrypted = msEncrypt.ToArray(); 
                    }
                    encrypted = msEncrypt.ToArray();
                    return encrypted;
                }
            }
        }
