    private static void Enc(string decryptedFileName, string encryptedFileName)
    {
        PasswordDeriveBytes passwordDB = new PasswordDeriveBytes("ThisIsMyPassword", Encoding.ASCII.GetBytes("thisIsMysalt!"), "MD5", 2);
        byte[] passwordBytes = passwordDB.GetBytes(128 / 8);
        using (FileStream fsOutput = File.OpenWrite(encryptedFileName))
        {
            using(FileStream fsInput = File.OpenRead(decryptedFileName))
            {
                byte[] IVBytes = Encoding.ASCII.GetBytes("1234567890123456");
                RijndaelManaged symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC,Padding=PaddingMode.Zeros};
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(passwordBytes, IVBytes);
                using (CryptoStream cryptoStream = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                {
                    byte[] chunkData = new byte[chunkSize];
                    int bytesRead = 0;
                    while ((bytesRead = fsInput.Read(chunkData, 0, chunkSize)) > 0)
                    {
                        cryptoStream.Write(chunkData, 0, bytesRead);  //KEY FIX
                    }
                }
            }
        }            
    }
