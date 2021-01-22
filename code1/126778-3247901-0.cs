        public Byte[] Encrypt(Byte[] data, String password)
        {
            //Just random 8 bytes for salt
            var salt = new Byte[] {1, 2, 3, 4, 5, 6, 7, 8};
            using (var cc = new CipherContext(Cipher.AES_256_CBC))
            {
                //Constructing key and init vector from string password
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] iv;
                byte[] key = cc.BytesToKey(MessageDigest.MD5, salt, passwordBytes, 1, out iv);
                var memoryStream = new MemoryStream();
                
                //Performing encryption thru unmanaged wrapper
                var aesData = cc.Crypt(data, key, iv, true);
                //Append salt so final data will look Salted___SALT|RESTOFTHEDATA
                memoryStream.Write(Encoding.UTF8.GetBytes("Salted__"), 0, 8);
                memoryStream.Write(salt, 0, 8);
                memoryStream.Write(aesData, 0, aesData.Length);
                return memoryStream.ToArray();
            }
        }
        
        public Byte[] Decrypt(String password, Byte[] encryptedData)
        {
            byte[] salt = null;
            //extracting salt if presented
            if (encryptedData.Length > 16)
            {
                if (Encoding.UTF8.GetString(encryptedData).StartsWith("Salted__"))
                {
                    salt = new Byte[8];
                    Buffer.BlockCopy(encryptedData, 8, salt, 0, 8);
                }
            }
            
            //Removing salt from the original array
            int aesDataLength = encryptedData.Length - 16;
            byte[] aesData = new byte[aesDataLength];
            Buffer.BlockCopy(encryptedData, 16, aesData, 0, aesDataLength);
            
            using (var cc = new CipherContext(Cipher.AES_256_CBC))
            {
                //Constructing key and init vector from string password and salt
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] iv;
                byte[] key = cc.BytesToKey(MessageDigest.MD5, salt, passwordBytes, 1, out iv);
                
                //Decrypting
                return cc.Decrypt(aesData, key, iv, 0);
            }
            
        }
