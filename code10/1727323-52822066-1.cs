        string keyString = "00000000000000000000000000000000"; //replace with your key
    string ivString = "0000000000000000"; //replace with your iv
    
    byte[] key = Encoding.ASCII.GetBytes(keyString);
    byte[] iv = Encoding.ASCII.GetBytes(ivString);
    
    using (var rijndaelManaged =
            new RijndaelManaged { Key = key, IV = iv, Mode = CipherMode.CBC })
            {
                rijndaelManaged.BlockSize = 128;
                rijndaelManaged.KeySize = 256;
                using (var memoryStream =
                       new MemoryStream(Convert.FromBase64String(AuthorizationCode)))
                using (var cryptoStream =
                       new CryptoStream(memoryStream,
                           rijndaelManaged.CreateDecryptor(key, iv),
                           CryptoStreamMode.Read))
                {
                    return new StreamReader(cryptoStream).ReadToEnd();
                }
            }
