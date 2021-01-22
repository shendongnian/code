    string plainText = "This will be encrypted.";
    RijndaelManaged aesAlg = new RijndaelManaged();
    aesAlg.Key = new byte[32] { 118, 123, 23, 17, 161, 152, 35, 68, 126, 213, 16, 115, 68, 217, 58, 108, 56, 218, 5, 78, 28, 128, 113, 208, 61, 56, 10, 87, 187, 162, 233, 38 };
    aesAlg.IV = new byte[16] { 33, 241, 14, 16, 103, 18, 14, 248, 4, 54, 18, 5, 60, 76, 16, 191};
    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
    msEncrypt = new MemoryStream();
    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) {
            swEncrypt.Write(plainText);
        }
    }
    return msEncrypt.ToArray();
