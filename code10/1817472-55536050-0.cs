     public sealed class MyCryptoClass
        {
            protected AesManaged myRijndael;
    
            private static string encryptionKey = "MyKey";
            private static string salt = "Mysalt";
            private static byte[] initialisationVector = new byte[16];
    		//private static byte[] initialisationVector = Encoding.UTF8.GetBytes("l4iG63jN9Dcg6537");
            private static byte[] secretKey = GetSecretKey();
           
    
            // Singleton pattern used here with ensured thread safety
            protected static readonly MyCryptoClass _instance = new MyCryptoClass();
            public static MyCryptoClass Instance
            {
                get { return _instance; }
            }
    
            public MyCryptoClass()
            {
    
            }
            public string DecryptText(string encryptedString)
            {
                using (myRijndael = new AesManaged())
                {
                    myRijndael.Key = Convert.FromBase64String(encryptionKey);
                    myRijndael.IV = new byte[16];
                    myRijndael.Mode = CipherMode.CBC;
                    myRijndael.Padding = PaddingMode.PKCS7;
    
                    Byte[] ourEnc = Convert.FromBase64String(encryptedString);
                    string ourDec = DecryptStringFromBytes(ourEnc, myRijndael.Key, myRijndael.IV);
    
                    return ourDec;
                }
            }
            public string EncryptText(string plainText)
            {
                using (myRijndael = new AesManaged())
                {
                   
                    myRijndael.Key = secretKey;
                    myRijndael.IV = initialisationVector;
                    myRijndael.Mode = CipherMode.CBC;
                    myRijndael.Padding = PaddingMode.PKCS7;
    
                    byte[] encrypted = EncryptStringToBytes(plainText, myRijndael.Key, myRijndael.IV);
                    string encString = Convert.ToBase64String(encrypted);
    
                    return encString;
                }
            }
            protected byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
            {
                // Check arguments. 
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
                byte[] encrypted;
                // Create an RijndaelManaged object 
                // with the specified key and IV. 
                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = Key;
                    rijAlg.IV = IV;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
    
                    // Create the streams used for encryption. 
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
    
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
                // Return the encrypted bytes from the memory stream. 
                return encrypted;
    
            }
            protected string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
            {
                // Check arguments. 
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
    
                // Declare the string used to hold 
                // the decrypted text. 
                string plaintext = null;
    
                // Create an RijndaelManaged object 
                // with the specified key and IV. 
                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = Key;
                    rijAlg.IV = IV;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
    
                    // Create the streams used for decryption. 
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
    
                                // Read the decrypted bytes from the decrypting stream 
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                return plaintext;
            }
    
            public static void GenerateKeyAndIV()
            {
                // This code is only here for an example
                AesManaged myRijndaelManaged = new AesManaged();
                myRijndaelManaged.Mode = CipherMode.CBC;
                myRijndaelManaged.Padding = PaddingMode.PKCS7;
    
                myRijndaelManaged.GenerateIV();
                myRijndaelManaged.GenerateKey();
                string newKey = ByteArrayToHexString(myRijndaelManaged.Key);
                string newinitVector = ByteArrayToHexString(myRijndaelManaged.IV);
            }
    
            protected static byte[] HexStringToByte(string hexString)
            {
                try
                {
                    int bytesCount = (hexString.Length) / 2;
                    byte[] bytes = new byte[bytesCount];
                    for (int x = 0; x < bytesCount; ++x)
                    {
                        bytes[x] = Convert.ToByte(hexString.Substring(x * 2, 2), 16);
                    }
                    return bytes;
                }
                catch
                {
                    throw;
                }
            }
    
            public static string ByteArrayToHexString(byte[] ba)
            {
                StringBuilder hex = new StringBuilder(ba.Length * 2);
                foreach (byte b in ba)
                    hex.AppendFormat("{0:x2}", b);
                return hex.ToString();
            }
    
            private static byte[] GetSecretKey()
            {
                string hashedKey = GetHashedKey();
                byte[] saltBytes = Encoding.UTF8.GetBytes(salt); // builder.mCharsetName = "UTF8";
                int iterations = 1; // builder.mIterationCount = 1
                byte[] secretKey = null;
                using (Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(hashedKey, saltBytes, iterations)) // builder.mSecretKeyType = "PBKDF2WithHmacSHA1";
                {
                    secretKey = rfc2898.GetBytes(16); // builder.mKeyLength = 128;
                    //Console.WriteLine("Key: " + ByteArrayToHexString(secretKey));
                }
                return secretKey;
            }
    
            private static string GetHashedKey()
            {
                string hashBase64 = String.Empty;
                using (SHA1Managed sha1 = new SHA1Managed()) // builder.mDigestAlgorithm = "SHA1";
                {
                    byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(encryptionKey)); // builder.mCharsetName = "UTF8";
    
                    hashBase64 = Base64ThirdPartAndroid(hash, true);
                    //hashBase64 = Base64ThirdPartAndroid(hash, true);
                    //Console.WriteLine("Hash (base64): " + hashBase64);
                }
                return hashBase64;
            }
    
            private static string Base64ThirdPartAndroid(byte[] arr, bool withoutPadding)
            {
                string base64String = System.Convert.ToBase64String(arr);
                if (withoutPadding) base64String = base64String.TrimEnd('='); // Remove trailing "="-characters
                base64String += "\n"; // Append LF (10)
                //Console.WriteLine("Array as base64 encoded string: " + base64String);
                return base64String;
            }
        }
