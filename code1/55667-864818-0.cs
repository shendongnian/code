     public static void EncDecString()
            {
                string encryptedString = CryptoString.Encrypt("MyPassword");
                Console.WriteLine("encryptedString: " + encryptedString);
                // get the key and IV used so you can decrypt it later
                byte [] key = CryptoString.Key;
                byte [] IV = CryptoString.IV;
    
                CryptoString.Key = key;
                CryptoString.IV = IV;
                string decryptedString = CryptoString.Decrypt(encryptedString);
                Console.WriteLine("decryptedString: " + decryptedString);
    
            }
    
            public sealed class CryptoString
            {
                private CryptoString() {}
    
                private static byte[] savedKey = null;
                private static byte[] savedIV = null;
    
                public static byte[] Key
                {
                    get { return savedKey; }
                    set { savedKey = value; }
                }
    
                public static byte[] IV
                {
                    get { return savedIV; }
                    set { savedIV = value; }
                }
    
                private static void RdGenerateSecretKey(RijndaelManaged rdProvider)
                {
                    if (savedKey == null)
                    {
                        rdProvider.KeySize = 256;
                        rdProvider.GenerateKey();
                        savedKey = rdProvider.Key;
                    }
                }
    
                private static void RdGenerateSecretInitVector(RijndaelManaged rdProvider)
                {
                    if (savedIV == null)
                    {
                        rdProvider.GenerateIV();
                        savedIV = rdProvider.IV;
                    }
                }
    
                public static string Encrypt(string originalStr)
                {
                    // Encode data string to be stored in memory
                    byte[] originalStrAsBytes = Encoding.ASCII.GetBytes(originalStr);
                    byte[] originalBytes = {};
    
                    // Create MemoryStream to contain output
                    MemoryStream memStream = new MemoryStream(originalStrAsBytes.Length);
    
                    RijndaelManaged rijndael = new RijndaelManaged();
    
                    // Generate and save secret key and init vector
                    RdGenerateSecretKey(rijndael);
                    RdGenerateSecretInitVector(rijndael);
    
                    if (savedKey == null || savedIV == null)
                    {
                        throw (new NullReferenceException(
                            "savedKey and savedIV must be non-null."));
                    }
    
                    // Create encryptor, and stream objects
                    ICryptoTransform rdTransform = 
                        rijndael.CreateEncryptor((byte[])savedKey.Clone(),
                                                (byte[])savedIV.Clone());
                    CryptoStream cryptoStream = new CryptoStream(memStream, rdTransform, 
                        CryptoStreamMode.Write);
    
                    // Write encrypted data to the MemoryStream
                    cryptoStream.Write(originalStrAsBytes, 0, originalStrAsBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    originalBytes = memStream.ToArray();
    
                    // Release all resources
                    memStream.Close();
                    cryptoStream.Close();
                    rdTransform.Dispose();
                    rijndael.Clear();
    
                    // Convert encrypted string
                    string encryptedStr = Convert.ToBase64String(originalBytes);
                    return (encryptedStr);
                }
    
                public static string Decrypt(string encryptedStr)
                {
                    // Unconvert encrypted string
                    byte[] encryptedStrAsBytes = Convert.FromBase64String(encryptedStr);
                    byte[] initialText = new Byte[encryptedStrAsBytes.Length];
    
                    RijndaelManaged rijndael = new RijndaelManaged();
                    MemoryStream memStream = new MemoryStream(encryptedStrAsBytes);
    
                    if (savedKey == null || savedIV == null)
                    {
                        throw (new NullReferenceException(
                            "savedKey and savedIV must be non-null."));
                    }
    
                    // Create decryptor, and stream objects
                    ICryptoTransform rdTransform = 
                        rijndael.CreateDecryptor((byte[])savedKey.Clone(), 
                                                (byte[])savedIV.Clone());
                    CryptoStream cryptoStream = new CryptoStream(memStream, rdTransform, 
                        CryptoStreamMode.Read);
    
                    // Read in decrypted string as a byte[]
                    cryptoStream.Read(initialText, 0, initialText.Length);
    
                    // Release all resources
                    memStream.Close();
                    cryptoStream.Close();
                    rdTransform.Dispose();
                    rijndael.Clear();
    
                    // Convert byte[] to string
                    string decryptedStr = Encoding.ASCII.GetString(initialText);
                    return (decryptedStr);
                }
            }
