    public static string Decrypt(string cipherText, string password) {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create()) {
            // extract salt (first 16 bytes)
            var salt = cipherBytes.Take(16).ToArray();
            // extract iv (next 16 bytes)
            var iv = cipherBytes.Skip(16).Take(16).ToArray();
            // the rest is encrypted data
            var encrypted = cipherBytes.Skip(32).ToArray();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, salt, 100);
            encryptor.Key = pdb.GetBytes(32);
            encryptor.Padding = PaddingMode.PKCS7;
            encryptor.Mode = CipherMode.CBC;
            encryptor.IV = iv;
            // you need to decrypt this way, not the way in your question
            using (MemoryStream ms = new MemoryStream(encrypted)) {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Read)) {
                    using (var reader = new StreamReader(cs, Encoding.UTF8)) {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }    
