            private static void Enc(string decryptedFileName, string encryptedFileName)
            {
                PasswordDeriveBytes passwordDB = new PasswordDeriveBytes("ThisIsMyPassword", Encoding.ASCII.GetBytes("thisIsMysalt!"), "MD5", 2);
                byte[] passwordBytes = passwordDB.GetBytes(128 / 8);
    
                using (FileStream fsOutput = File.OpenWrite(encryptedFileName))
                {
                    using(FileStream fsInput = File.OpenRead(decryptedFileName))
                    {
                        byte[] IVBytes = Encoding.ASCII.GetBytes("1234567890123456");
    
                        fsOutput.Write(BitConverter.GetBytes(fsInput.Length), 0, 8);
                        fsOutput.Write(IVBytes, 0, 16);
    
                        RijndaelManaged symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC,Padding=PaddingMode.ANSIX923};
                        ICryptoTransform encryptor = symmetricKey.CreateEncryptor(passwordBytes, IVBytes);                   
    
                        using (CryptoStream cryptoStream = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                        {
                            for (long i = 0; i < fsInput.Length; i += chunkSize)
                            {
                                byte[] chunkData = new byte[chunkSize];
                                int bytesRead = 0;
                                while ((bytesRead = fsInput.Read(chunkData, 0, chunkSize)) > 0)
                                {
                                    if (bytesRead != 16)
                                    {
                                        for (int x = bytesRead - 1; x < chunkSize; x++)
                                        {
                                            chunkData[x] = 0;
                                        }
                                    }
                                    cryptoStream.Write(chunkData, 0, chunkSize);
                                }
                            }
                            cryptoStream.FlushFinalBlock();
                        }
                    }
                }            
            }
    
            private static void Dec(string encryptedFileName, string decryptedFileName)
            {
                PasswordDeriveBytes passwordDB = new PasswordDeriveBytes("ThisIsMyPassword", Encoding.ASCII.GetBytes("thisIsMysalt!"), "MD5", 2);
                byte[] passwordBytes = passwordDB.GetBytes(128 / 8);
    
                using (FileStream fsInput = File.OpenRead(encryptedFileName))
                {
                    using (FileStream fsOutput = File.OpenWrite(decryptedFileName))
                    {
                        byte[] buffer = new byte[8];
                        fsInput.Read(buffer, 0, 8);
    
                        long fileLength = BitConverter.ToInt64(buffer, 0);
    
                        byte[] IVBytes = new byte[16];
                        fsInput.Read(IVBytes, 0, 16);
    
    
                        RijndaelManaged symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC,Padding=PaddingMode.ANSIX923};
                        ICryptoTransform decryptor = symmetricKey.CreateDecryptor(passwordBytes, IVBytes);
                        
                        using (CryptoStream cryptoStream = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write))
                        {
                            for (long i = 0; i < fsInput.Length; i += chunkSize)
                            {
                                byte[] chunkData = new byte[chunkSize];
                                int bytesRead = 0;
                                while ((bytesRead = fsInput.Read(chunkData, 0, chunkSize)) > 0)
                                {
                                    cryptoStream.Write(chunkData, 0, bytesRead);
                                }
                            }
                        }
                    }
                }
            }
