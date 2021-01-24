    public class Cryptography : IDisposable
    {
        private Aes Encryptor;
        public Cryptography(string key)
        {
            Encryptor = Aes.Create();
            var pdb = new Rfc2898DeriveBytes(key, new byte[]
                {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
            Encryptor.Key = pdb.GetBytes(32);
            Encryptor.IV = pdb.GetBytes(16);
        }
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;
            var clearBytes = Encoding.Unicode.GetBytes(plainText);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, Encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                }
                plainText = Convert.ToBase64String(ms.ToArray());
            }
            return plainText;
        }
        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, Encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
            return cipherText;
        }
        public void Dispose()
        {
            Encryptor.Dispose();
        }
    }
