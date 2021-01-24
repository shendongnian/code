    static string encrypt(string clearText = "")
    {
        if (clearText == null)
        {
            clearText = "";
        }
        string EncryptionKey = "****";
        byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
           Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }, 100000, HashAlgorithmName.SHA1);
           encryptor.Key = pdb.GetBytes(32);
           encryptor.IV = pdb.GetBytes(16);
           encryptor.Mode = CipherMode.CBC;
           using (MemoryStream ms = new MemoryStream())
           {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
            clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    } 
