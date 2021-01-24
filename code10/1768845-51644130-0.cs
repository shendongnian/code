        public static string Encrypt(string plaintext, string key, string vector)
        {
            return Encrypt(plaintext, key, Encoding.UTF8.GetBytes(vector));
        }
        public static string Encrypt(string plaintext, string key, byte[] vector)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(plaintext), key, vector));
        }
        public static byte[] Encrypt(byte[] plaintext, string key, byte[] vector)
        {
            using (var rijndael = new RijndaelManaged() { Key = Encoding.UTF8.GetBytes(key), Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7, IV = vector })
            using (var encryptor = rijndael.CreateEncryptor())
            {
                var resultArray = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);
                return resultArray;
            }
        }
        public static string Decrypt(string ciphertext, string key, string vector)
        {
            return Decrypt(ciphertext, key, Encoding.UTF8.GetBytes(vector));
        }
        public static string Decrypt(string ciphertext, string key, byte[] vector)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(ciphertext), key, vector));
        }
        public static byte[] Decrypt(byte[] ciphertext, string key, byte[] vector)
        {
            using (var rijndael = new RijndaelManaged() { Key = Encoding.UTF8.GetBytes(key), Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7, IV = vector })
            using (var decryptor = rijndael.CreateDecryptor())
            {
                var resultArray = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
                return resultArray;
            }
        }
    }
