    public class AES256Hash
        {
            private static byte[] key;
            private static Object mutex = new Object();
    
            private const int KEY_SIZE = 256;
            private const int BLOCK_SIZE = 128;
            private const int IV_KEY_SIZE = 16; // 16 byte
    
            private AES256Hash()
            {
            }
    
            /// <summary>
            /// Create a new randomized cipher on each startup
            /// </summary>
            private static void InitializeCipherKey()
            {
                lock (mutex)
                {
                    if (key == null)
                    {
                        key = new byte[32];
    
                        var cr = new System.Security.Cryptography.RNGCryptoServiceProvider();
                        cr.GetBytes(key, 0, key.Length);
                    }
                }
            }
    
            /// <summary>
            /// Converts the input data into an IV key
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            private static byte[] CreateIvKey(string Data)
            {
                byte[] IvKey = new UTF8Encoding().GetBytes(Data);
                if (IvKey.Length != IV_KEY_SIZE)
                {
                    byte[] NewTruncatedIvKey = new byte[IV_KEY_SIZE];
                    Buffer.BlockCopy(IvKey, 0, NewTruncatedIvKey, 0, Math.Min(IV_KEY_SIZE, IvKey.Length)); // the rest of the bytes are 0 padded
    
                    return NewTruncatedIvKey;
                }
                return IvKey;
            }
    
            /// <summary>
            /// Encrypts a string with AES256 with the given key and string data
            /// </summary>
            /// <param name="Key"></param>
            /// <param name="Data"></param>
            /// <returns></returns>
            public static string EncryptString(string Key, string Data)
            {
                InitializeCipherKey();
    
                byte[] IvKey = CreateIvKey(Key);
                byte[] dataB = new UTF8Encoding().GetBytes(Data);
    
                using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
                {
                    csp.Padding = PaddingMode.PKCS7;
                    csp.Mode = CipherMode.ECB;
    
                    csp.KeySize = KEY_SIZE;
                    csp.BlockSize = BLOCK_SIZE;
                    csp.Key = key;
                    csp.IV = IvKey;
                    ICryptoTransform encrypter = csp.CreateEncryptor();
    
                    return Convert.ToBase64String(encrypter.TransformFinalBlock(dataB, 0, dataB.Length));
                }
            }
    
            /// <summary>
            /// Decrypts a string with AES256 with the given key and string data
            /// </summary>
            /// <param name="Key"></param>
            /// <param name="Data"></param>
            /// <returns></returns>
            public static string DecryptString(string Key, string Data)
            {
                InitializeCipherKey();
       
                byte[] IvKey = CreateIvKey(Key);
                byte[] dataB = Convert.FromBase64String(Data);
    
                using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
                {
                    csp.Padding = PaddingMode.PKCS7;
                    csp.Mode = CipherMode.ECB;
    
                    csp.KeySize = KEY_SIZE;
                    csp.BlockSize = BLOCK_SIZE;
                    csp.Key = key;
                    csp.IV = IvKey;
                    ICryptoTransform decrypter = csp.CreateDecryptor();
    
                    return new UTF8Encoding().GetString( decrypter.TransformFinalBlock(dataB, 0, dataB.Length) );
                }
            }
        }
