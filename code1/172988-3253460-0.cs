    public static byte[] Encrypt(string password, string plaintext, SymmetricAlgorithm algorithm)
    {
        byte[] key, iv;
        CreateKeyIV(password, out key, out iv);
        using (MemoryStream encrypted = new MemoryStream())
        {
            using (CryptoStream enc = new CryptoStream(encrypted, algorithm.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            using (StreamWriter writer = new StreamWriter(enc))
                writer.Write(plaintext);
            return encrypted.ToArray();
        }
    }
