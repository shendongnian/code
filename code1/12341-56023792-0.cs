    public class EncryptionHelper
    {
        private Aes aesEncryptor;
        public EncryptionHelper()
        {
        }
        private void BuildAesEncryptor(string key)
        {
            aesEncryptor = Aes.Create();
            var pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            aesEncryptor.Key = pdb.GetBytes(32);
            aesEncryptor.IV = pdb.GetBytes(16);
        }
        public string EncryptString(string clearText, string key)
        {
            BuildAesEncryptor(key);
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aesEncryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                }
                var encryptedText = Convert.ToBase64String(ms.ToArray());
                return encryptedText;
            }
        }
        public string DecryptString(string cipherText, string key)
        {
            BuildAesEncryptor(key);
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aesEncryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                }
                var clearText = Encoding.Unicode.GetString(ms.ToArray());
                return clearText;
            }
        }
    }
