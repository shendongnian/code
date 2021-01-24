        public CryptoHelper(string keyFilePath, string ivFilePath)
        {
			//Reading bytes from txt file encoded in UTF8.
            byte[] key = File.ReadAllBytes(keyFilePath);
            byte[] iv = File.ReadAllBytes(ivFilePath);
            
            IV = StringToByteArray(GetStringHexSha256Hash(iv).Substring(0, 16));
            Key = StringToByteArray(GetStringHexSha256Hash(key).Substring(0, 32)); 
			//Tests
            var st = Encrypt("abcdefg");
            var en = Decrypt(st);
        }
		
		
		//Convert each char into a byte
		private byte[] StringToByteArray(string hex)
        {
            IList<byte> resultList = new List<byte>();
            foreach (char c in hex)
            {
                resultList.Add(Convert.ToByte(c));
            }
            return resultList.ToArray();
        }
        private string GetStringHexSha256Hash(byte[] source)
        {
            string result = "";
            try
            {
                using (SHA256 sha256Hash = SHA256.Create("SHA256"))
                {
					//Get rid of Encoding!
                    byte[] hashedBytes = sha256Hash.ComputeHash(source);
                    for (int i = 0; i < hashedBytes.Length; i++)
                    {
                        result = string.Format("{0}{1}",
                                                result,
                                                hashedBytes[i].ToString("x2"));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
		
		
        private string Encrypt(string source)
        {
            try
            {
                string result = "";
                using (var aes = new AesManaged { Key = Key, IV = IV, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    byte[] sourceByteArray = Encoding.UTF8.GetBytes(source);
                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        byte[] encriptedSource = encryptor.TransformFinalBlock(sourceByteArray, 0, sourceByteArray.Length);
                        result = Convert.ToBase64String(encriptedSource);
						//Nothing to see here, move along.
                        result = Convert.ToBase64String(Encoding.UTF8.GetBytes(result));
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private string Decrypt(string source)
        {
            try
            {
                string result = "";
                byte[] sourceByte = Convert.FromBase64String(source);
                byte[] sourceFreeOfBase64 = Convert.FromBase64String(Encoding.UTF8.GetString(sourceByte));
                byte[] resultByte;
                int decryptedByteCount = 0;
                using (var aes = new AesManaged { Key = Key, IV = IV, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    using (ICryptoTransform AESDecrypt = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(sourceFreeOfBase64))
                        {
                            using (CryptoStream cs = new CryptoStream(memoryStream, AESDecrypt, CryptoStreamMode.Read))
                            {
                                resultByte = new byte[sourceFreeOfBase64.Length];
								//Now that everything works as expected I actually get the number of bytes decrypted!
                                decryptedByteCount = cs.Read(resultByte, 0, resultByte.Length);
                            }
                        }
                    }
					//Nothing to see here, move along.
					result = Encoding.UTF8.GetString(resultByte);
					//Use that byte count to get the actual data and discard the padding.
                    result = result.Substring(0, decryptedByteCount);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
		
