    class AesExample
        {
            public static void Main()
            {
                try
                {
    
                    string original = "Here is some data to encrypt!";
    
                    // Create a new instance of the AesManaged
                    // class.  This generates a new key and initialization 
                    // vector (IV).
                    using (AesManaged myAes = new AesManaged())
                    {
    
                        // Encrypt the string to an array of bytes.
                        string encrypted = EncryptPasswordAes(original, myAes.Key, myAes.IV);
    
                        // Decrypt the bytes to a string.
                        string roundtrip = DecryptPasswordAes(encrypted, myAes.Key, myAes.IV);
    
                        //Display the original data and the decrypted data.
                        Console.WriteLine("Original:   {0}", original);
                        Console.WriteLine("Encrypted: {0}", encrypted);
                        Console.WriteLine("Round Trip: {0}", roundtrip);
    
                        Console.ReadLine();
                    }
    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }
            static string EncryptPasswordAes(string plainText, byte[] Key, byte[] IV)
            {
                // Check arguments.
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
                byte[] encrypted;
                // Create an AesManaged object
                // with the specified key and IV.
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
    
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
                return Convert.ToBase64String(encrypted);
    
            }
    
            static string DecryptPasswordAes(string encryptedString, byte[] Key, byte[] IV)
            {
                //Convert cipher text back to byte array
                byte[] cipherText = Convert.FromBase64String(encryptedString);
                //  Byte[] cipherText = System.Text.Encoding.UTF8.GetBytes(encryptedString);
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
    
                // Create an AesManaged object
                // with the specified key and IV.
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
    
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
        }
