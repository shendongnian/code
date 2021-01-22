    byte[] rawPlaintext = System.Text.Encoding.Unicode.GetBytes("This is all clear now!");
    using (Aes aes = new AesManaged())
    {
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = new byte[128/8];
        aes.IV = new byte[128/8];
        byte[] cipherText= null;
        byte[] plainText= null;
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(rawPlaintext, 0, rawPlaintext.Length);
            }
            cipherText= ms.ToArray();
        }
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cipherText, 0, cipherText.Length);
            }
            plainText = ms.ToArray();
        }
        string s = System.Text.Encoding.Unicode.GetString(plainText);
        Console.WriteLine(s);
    }
