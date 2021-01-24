    public static class SimpleFernet
    {
        // Fernet: from https://github.com/fernet/spec/blob/master/Spec.md
        // return value is base64 url encoded
        // trimEnd is to force trimming of return value
        public static string EncryptFernet(byte[] key, byte[] data, DateTime? timestamp = null, byte[] iv = null, bool trimEnd = false)
        {
            // Fernet: from https://github.com/fernet/spec/blob/master/Spec.md
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length != 32)
            {
                throw new ArgumentException(nameof(key));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (iv != null && iv.Length != 16)
            {
                throw new ArgumentException(nameof(iv));
            }
            if (timestamp == null)
            {
                timestamp = DateTime.UtcNow;
            }
            byte[] result = new byte[57 + ((data.Length + 16) / 16 * 16)];
            result[0] = 0x80;
            {
                // BigEndian to LittleEndian
                long timestamp2 = new DateTimeOffset(timestamp.Value).ToUnixTimeSeconds();
                timestamp2 = IPAddress.NetworkToHostOrder(timestamp2);
                byte[] timestamp3 = BitConverter.GetBytes(timestamp2);
                Buffer.BlockCopy(timestamp3, 0, result, 1, timestamp3.Length);
            }
            using (var aes = new AesManaged())
            {
                aes.Mode = CipherMode.CBC;
                byte[] encryptionKey = new byte[16];
                Buffer.BlockCopy(key, 16, encryptionKey, 0, 16);
                aes.Key = encryptionKey;
                if (iv != null)
                {
                    aes.IV = iv;
                }
                else
                {
                    aes.GenerateIV();
                }
                Buffer.BlockCopy(aes.IV, 0, result, 9, 16);
                aes.Padding = PaddingMode.PKCS7;
                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);
                    Buffer.BlockCopy(encrypted, 0, result, 25, encrypted.Length);
                }
            }
            byte[] signingKey = new byte[16];
            Buffer.BlockCopy(key, 0, signingKey, 0, 16);
            using (var hmac = new HMACSHA256(signingKey))
            {
                hmac.TransformFinalBlock(result, 0, result.Length - 32);
                Buffer.BlockCopy(hmac.Hash, 0, result, result.Length - 32, 32);
            }
            return Base64UrlEncode(result, trimEnd);
        }
        // Token is base64 url encoded
        public static byte[] DecryptFernet(byte[] key, string token, out DateTime timestamp)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length != 32)
            {
                throw new ArgumentException(nameof(key));
            }
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            byte[] token2 = Base64UrlDecode(token);
            if (token2.Length < 57)
            {
                throw new ArgumentException(nameof(token));
            }
            byte version = token2[0];
            if (version != 0x80)
            {
                throw new Exception("version");
            }
            // Check the hmac
            {
                byte[] signingKey = new byte[16];
                Buffer.BlockCopy(key, 0, signingKey, 0, 16);
                using (var hmac = new HMACSHA256(signingKey))
                {
                    hmac.TransformFinalBlock(token2, 0, token2.Length - 32);
                    byte[] hash2 = hmac.Hash;
                    IEnumerable<byte> hash = token2.Skip(token2.Length - 32).Take(32);
                    if (!hash.SequenceEqual(hash2))
                    {
                        throw new Exception("Wrong HMAC!");
                    }
                }
            }
            {
                // BigEndian to LittleEndian
                long timestamp2 = BitConverter.ToInt64(token2, 1);
                timestamp2 = IPAddress.NetworkToHostOrder(timestamp2);
                timestamp = DateTimeOffset.FromUnixTimeSeconds(timestamp2).UtcDateTime;
            }
            byte[] decrypted;
            using (var aes = new AesManaged())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                byte[] encryptionKey = new byte[16];
                Buffer.BlockCopy(key, 16, encryptionKey, 0, 16);
                aes.Key = encryptionKey;
                byte[] iv = new byte[16];
                Buffer.BlockCopy(token2, 9, iv, 0, 16);
                aes.IV = iv;
                using (var decryptor = aes.CreateDecryptor())
                {
                    const int startCipherText = 25;
                    int cipherTextLength = token2.Length - 32 - 25;
                    decrypted = decryptor.TransformFinalBlock(token2, startCipherText, cipherTextLength);
                }
            }
            return decrypted;
        }
        public static string Base64UrlEncode(byte[] bytes, bool trimEnd = false)
        {
            int length = (bytes.Length + 2) / 3 * 4; ;
            var chars = new char[length];
            Convert.ToBase64CharArray(bytes, 0, bytes.Length, chars, 0);
            int trimmedLength = length;
            if (trimEnd)
            {
                switch (bytes.Length % 3)
                {
                    case 1:
                        trimmedLength -= 2;
                        break;
                    case 2:
                        trimmedLength -= 1;
                        break;
                }
            }
            for (int i = 0; i < trimmedLength; i++)
            {
                switch (chars[i])
                {
                    case '/':
                        chars[i] = '_';
                        break;
                    case '+':
                        chars[i] = '-';
                        break;
                }
            }
            string result = new string(chars, 0, trimmedLength);
            return result;
        }
        public static byte[] Base64UrlDecode(string s)
        {
            // https://stackoverflow.com/a/26354677/613130
            // But totally rewritten :-)
            char[] chars;
            switch (s.Length % 4)
            {
                case 2:
                    chars = new char[s.Length + 2];
                    chars[chars.Length - 2] = '=';
                    chars[chars.Length - 1] = '=';
                    break;
                case 3:
                    chars = new char[s.Length + 1];
                    chars[chars.Length - 1] = '=';
                    break;
                default:
                    chars = new char[s.Length];
                    break;
            }
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '_':
                        chars[i] = '/';
                        break;
                    case '-':
                        chars[i] = '+';
                        break;
                    default:
                        chars[i] = s[i];
                        break;
                }
            }
            byte[] result = Convert.FromBase64CharArray(chars, 0, chars.Length);
            return result;
        }
    }
    static void Main(string[] args)
    {
        // Test vector taken from https://github.com/fernet/spec/blob/master/generate.json
        byte[] key = Base64UrlDecode("cw_0x689RpI-jtRR7oE8h_eQsKImvJapLeSbXpwF4e4=");
        string token = "gAAAAAAdwJ6wAAECAwQFBgcICQoLDA0ODy021cpGVWKZ_eEwCGM4BLLF_5CV9dOPmrhuVUPgJobwOz7JcbmrR64jVmpU4IwqDA==";
        DateTime timestamp;
        string result = DecryptFernet(key, token, out timestamp);
    }
