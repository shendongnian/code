     private string decyptInit(string toBeEncrypted, string key, string initVector)
        {
            var keyByte = Encoding.Default.GetBytes(key);
            var decodedIV = Base64Decode(initVector);
            var iv = Encoding.Default.GetBytes(decodedIV);
           
            var rijndael = new RijndaelManaged
            {
                BlockSize = 128,
                IV = iv,
                KeySize = 192,
                Key = keyByte
            };
            var buffer = Convert.FromBase64String(toBeEncrypted);
            var transform = rijndael.CreateDecryptor();
            string decrypted;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                {
                    cs.Write(buffer, 0, buffer.Length);
                    cs.FlushFinalBlock();
                    decrypted = Encoding.UTF8.GetString(ms.ToArray());
                    cs.Close();
                }
                ms.Close();
            }
            return decrypted;
        }
