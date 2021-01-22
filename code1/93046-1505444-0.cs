     /// <summary>
            /// Encrypts the string.
            /// </summary>
            /// <param name="text">The text.</param>
            /// <returns>Encrypted string</returns>
            public string EncryptString(string text)
            {
                // Locals
                var passphrase = ConfigurationManager.AppSettings["Your Encrypt Passphrase"];
                byte[] results;
                var utf8 = new UTF8Encoding();
    
                // Step 1. We hash the passphrase using MD5
                // We use the MD5 hash generator as the result is a 128 bit byte array
                // which is a valid length for the TripleDES encoder we use below
                var hashProvider = new MD5CryptoServiceProvider();
                var tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));
    
                // Step 2. Create a new TripleDESCryptoServiceProvider object
                // Step 3. Setup the encoder
                var tdesAlgorithm = new TripleDESCryptoServiceProvider
                                        {
                                            Key = tdesKey,
                                            Mode = CipherMode.ECB,
                                            Padding = PaddingMode.PKCS7
                                        };
    
                // Step 4. Convert the input string to a byte[]
                var dataToEncrypt = utf8.GetBytes(text);
    
                // Step 5. Attempt to encrypt the string
                try
                {
                    var encryptor = tdesAlgorithm.CreateEncryptor();
                    results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information
                    tdesAlgorithm.Clear();
                    hashProvider.Clear();
                }
    
                // Step 6. Return the encrypted string as a base64 encoded string
                return Convert.ToBase64String(results);
            }
    
            /// <summary>
            /// Decrypts the string.
            /// </summary>
            /// <param name="text">The text.</param>
            /// <returns>Decrypted string</returns>
            public string DecryptString(string text)
            {
                // Locals
                var passphrase = ConfigurationManager.AppSettings["Your Encrypt Passphrase"];
                byte[] results;
                var utf8 = new UTF8Encoding();
    
                // Step 1. We hash the passphrase using MD5
                // We use the MD5 hash generator as the result is a 128 bit byte array
                // which is a valid length for the TripleDES encoder we use below
                var hashProvider = new MD5CryptoServiceProvider();
                var tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));
    
                // Step 2. Create a new TripleDESCryptoServiceProvider object
                // Step 3. Setup the decoder
                var tdesAlgorithm = new TripleDESCryptoServiceProvider
                                        {
                                            Key = tdesKey,
                                            Mode = CipherMode.ECB,
                                            Padding = PaddingMode.PKCS7
                                        };
    
                // Step 4. Convert the input string to a byte[]
                var dataToDecrypt = Convert.FromBase64String(text);
    
                // Step 5. Attempt to decrypt the string
                try
                {
                    var decryptor = tdesAlgorithm.CreateDecryptor();
                    results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information
                    tdesAlgorithm.Clear();
                    hashProvider.Clear();
                }
    
                // Step 6. Return the decrypted string in UTF8 format
                return utf8.GetString(results);
            }
