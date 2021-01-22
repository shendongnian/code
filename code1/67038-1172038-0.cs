    string PasswordEncryptionKey = "the Key"; //should be set somewhere else
    internal static byte[] EncryptPassword(string password)
    {
        MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
        byte[] key = hash.ComputeHash(
                        UTF8Encoding.UTF8.GetBytes(PasswordEncryptionKey));
        hash.Clear();
        RijndaelManaged rm = new RijndaelManaged();
        rm.Key = key;
        rm.Mode = CipherMode.ECB;
        rm.Padding = PaddingMode.PKCS7;
        ICryptoTransform transform = rm.CreateEncryptor();
        byte[] bytes = UTF8Encoding.UTF8.GetBytes(password);
        byte[] result = transform.TransformFinalBlock(bytes, 0, bytes.Length);
        rm.Clear();
        return result;
    }
    internal new static string DecryptPassword(byte[] encodedPassword)
    {
        MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
        byte[] key = hash.ComputeHash(
                              UTF8Encoding.UTF8.GetBytes(PasswordEncryptionKey));
        hash.Clear();
        RijndaelManaged rm = new RijndaelManaged();
        rm.Key = key;
        rm.Mode = CipherMode.ECB;
        rm.Padding = PaddingMode.PKCS7;
        ICryptoTransform transform = rm.CreateDecryptor();
        byte[] result = transform.TransformFinalBlock(
                                  encodedPassword, 0, encodedPassword.Length);
        rm.Clear();
        return UTF8Encoding.UTF8.GetString(result); ;
    }
