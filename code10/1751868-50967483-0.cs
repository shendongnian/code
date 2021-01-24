    public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv = null)
    {
        // Check arguments.
        if (plainText == null)
        {
            throw new ArgumentNullException("plainText");
        }
        if (key == null || key.Length == 0)
        {
            throw new ArgumentNullException("Key");
        }
        // Create an Aes object
        // with the specified key and IV.
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            if (iv == null)
            {
                iv = new byte[aes.BlockSize / 8];
                using (RandomNumberGenerator rngCryptoServiceProvider = RandomNumberGenerator.Create())
                {
                    rngCryptoServiceProvider.GetBytes(iv);
                }
            }
            // Note that we are setting IV, Mode, Padding
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            // Create an encryptor to perform the stream transform.
            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                // Prepend the IV
                cs.Write(iv, 0, iv.Length);
                // Here we are setting the Encoding
                using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
                {
                    // Write all data to the stream.
                    sw.Write(plainText);
                }
                byte[] encrypted = ms.ToArray();
                return encrypted;
            }
        }
    }
    public static string DecryptBytesToString_Aes(byte[] encrypted, byte[] key)
    {
        // Check arguments.
        if (encrypted == null || encrypted.Length == 0)
        {
            throw new ArgumentNullException("plainText");
        }
        if (key == null || key.Length == 0)
        {
            throw new ArgumentNullException("Key");
        }
        // Create an Aes object
        // with the specified key and IV.
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            using (MemoryStream ms = new MemoryStream(encrypted))
            {
                // Read the prepended IV
                var iv = new byte[aes.BlockSize / 8];
                ms.Read(iv, 0, iv.Length);
                // Note that we are setting IV, Mode, Padding
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                // Create an encryptor to perform the stream transform.
                using (ICryptoTransform decrytor = aes.CreateDecryptor())
                using (CryptoStream cs = new CryptoStream(ms, decrytor, CryptoStreamMode.Read))
                // Here we are setting the Encoding
                using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                {
                    // Read all data from the stream.
                    string plainText = sr.ReadToEnd();
                    return plainText;
                }
            }
        }
    }
    public static byte[] GenerateAesKey(int bits)
    {
        using (RandomNumberGenerator rngCryptoServiceProvider = RandomNumberGenerator.Create())
        {
            byte[] key = new byte[bits / 8];
            rngCryptoServiceProvider.GetBytes(key);
            return key;
        }
    }
    public static void Main()
    {
        var key = GenerateAesKey(256);
        var encrypted = EncryptStringToBytes_Aes("Hello", key);
        var decrypted = DecryptBytesToString_Aes(encrypted, key);
    }
