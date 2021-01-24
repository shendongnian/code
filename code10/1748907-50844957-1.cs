    // Token is base64 url encoded
    public static string DecryptFernet(byte[] key, string token)
    {
        // Fernet: from https://github.com/fernet/spec/blob/master/Spec.md
        byte[] token2 = Base64UrlDecode(token);
        byte version = token2[0];
        byte[] timestamp = new byte[8];
        Buffer.BlockCopy(token2, 1, timestamp, 0, 8);
        // BigEndian to LittleEndian
        Array.Reverse(timestamp);
        long timestamp2 = BitConverter.ToInt64(timestamp, 0);
        DateTime timestamp3 = new DateTime(1970, 1, 1).AddTicks(timestamp2 * TimeSpan.TicksPerSecond);
        // Contains the hmac
        if (key.Length == 32)
        {
            IEnumerable<byte> hash = token2.Skip(token2.Length - 32).Take(32);
            byte[] key2 = new byte[16];
            Buffer.BlockCopy(key, 0, key2, 0, 16);
            using (var hmac = new HMACSHA256(key2))
            {
                hmac.TransformFinalBlock(token2, 0, token2.Length - 32);
                byte[] hash2 = hmac.Hash;
                if (!hash.SequenceEqual(hash2))
                {
                    throw new Exception("Wrong HMAC!");
                }
            }
        }
        byte[] decrypted;
        using (var aes = new AesManaged())
        {
            aes.Mode = CipherMode.CBC;
            byte[] key2 = key;
            // If encryption key + signing key
            if (key.Length == 32)
            {
                key2 = new byte[16];
                Buffer.BlockCopy(key, 16, key2, 0, 16);
            }
            byte[] iv = new byte[16];
            Buffer.BlockCopy(token2, 9, iv, 0, 16);
            aes.Key = key2;
            aes.IV = iv;
            aes.Padding = PaddingMode.PKCS7;
            using (var decryptor = aes.CreateDecryptor())
            {
                int startCipherText = 25;
                int cipherTextLength = token2.Length - 32 - 25;
                decrypted = decryptor.TransformFinalBlock(token2, startCipherText, cipherTextLength);
            }
        }
        string result = Encoding.UTF8.GetString(decrypted);
        return result;
    }
    private static byte[] Base64UrlDecode(string token)
    {
        // https://stackoverflow.com/a/26354677/613130
        // But totally rewritten :-)
        char[] token2;
        switch (token.Length % 4)
        {
            case 2:
                token2 = new char[token.Length + 2];
                token2[token2.Length - 2] = '=';
                token2[token2.Length - 1] = '=';
                break;
            case 3:
                token2 = new char[token.Length + 1];
                token2[token2.Length - 1] = '=';
                break;
            default:
                token2 = new char[token.Length];
                break;
        }
        for (int i = 0; i < token.Length; i++)
        {
            switch (token[i])
            {
                case '_':
                    token2[i] = '/';
                    break;
                case '-':
                    token2[i] = '+';
                    break;
                default:
                    token2[i] = token[i];
                    break;
            }
        }
        byte[] result = Convert.FromBase64CharArray(token2, 0, token2.Length);
        return result;
    }
    static void Main(string[] args)
    {
        // Test vector taken from https://github.com/fernet/spec/blob/master/generate.json
        byte[] key = Base64UrlDecode("cw_0x689RpI-jtRR7oE8h_eQsKImvJapLeSbXpwF4e4=");
        string token = "gAAAAAAdwJ6wAAECAwQFBgcICQoLDA0ODy021cpGVWKZ_eEwCGM4BLLF_5CV9dOPmrhuVUPgJobwOz7JcbmrR64jVmpU4IwqDA==";
        string result = DecryptFernet(key, token);
    }
