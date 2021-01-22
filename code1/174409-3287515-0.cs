    public static string Decrypt(string password, Stream encrypted)
    {
        byte[] key, iv;
        CreateKeyIV(password, out key, out iv);
        using (CryptoStream dec = new CryptoStream(encrypted,
               _algorithm.CreateDecryptor(key, iv), CryptoStreamMode.Read))
        using (StreamReader reader = new StreamReader(dec))
        {
            return reader.ReadToEnd();
        }
     }
