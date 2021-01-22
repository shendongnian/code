    private static string CreateEncryptedString(string myString, string hexiv, string key)
            {
                RijndaelManaged alg = new RijndaelManaged();
                alg.Padding = PaddingMode.Zeros;
                alg.Mode = CipherMode.CBC;
                alg.BlockSize = 16 * 8;
                alg.Key = ASCIIEncoding.UTF8.GetBytes(key);
                alg.IV = StringToByteArray(hexiv);
                ICryptoTransform encryptor = alg.CreateEncryptor(alg.Key, alg.IV);
    
                MemoryStream msStream = new MemoryStream();
                CryptoStream mCSWriter = new CryptoStream(msStream, encryptor, CryptoStreamMode.Write);
                StreamWriter mSWriter = new StreamWriter(mCSWriter);
                mSWriter.Write(myString);
                mSWriter.Flush();
                mCSWriter.FlushFinalBlock();
    
                var EncryptedByte = new byte[msStream.Length];
                msStream.Position = 0;
                msStream.Read(EncryptedByte, 0, (int)msStream.Length);
    
                return ByteArrayToHexString(EncryptedByte);
              
            }
            public static byte[] StringToByteArray(String hex)
            {
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return bytes;
            }
            public static string ByteArrayToHexString(byte[] ba)
            {
                StringBuilder hex = new StringBuilder(ba.Length * 2);
                foreach (byte b in ba)
                    hex.AppendFormat("{0:x2}", b);
                return hex.ToString();
            }
