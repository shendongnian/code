      public class Cryptographyclass
            {
                private static  byte[] encrypted;
                private static byte[] _key;
                private static byte[] _iv;
                private Cryptographyclass()
                { }
        
                public static string Encrytion(string _PlainText)
                {
                    using (Aes _Aes = Aes.Create())
                    {
                        _key = _Aes.Key;
                        _iv = _Aes.IV;
                        // Encrypt the string to an array of bytes.
                        encrypted = EncryptStringToBytes_Aes(_PlainText, _Aes.Key, _Aes.IV);
                    }
                    return Convert.ToBase64String(encrypted);
                }
        
        
                private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
                {
                    // Check arguments.
                    if (plainText == null || plainText.Length <= 0)
                        throw new ArgumentNullException("plainText");
                    if (Key == null || Key.Length <= 0)
                        throw new ArgumentNullException("Key");
                    if (IV == null || IV.Length <= 0)
                        throw new ArgumentNullException("IV");
                    byte[] encrypted;
                    // Create an Aes object
                    // with the specified key and IV.
                    using (Aes aesAlg = Aes.Create())
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
                    return encrypted;
                }
        
                public static string Decryption(string _encryptedString)
                {
                    byte[] cipherTextBytes = Convert.FromBase64String(_encryptedString);
                    var _originalString = string.Empty;
                    using (Aes _Aes = Aes.Create())
                    {
                        // Encrypt the string to an array of bytes.
                        _originalString = DecryptStringFromBytes_Aes(cipherTextBytes, _key, _iv);
                    }
                    return _originalString;
                }
        
                private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
                {
                    if (cipherText == null || cipherText.Length <= 0)
                        throw new ArgumentNullException("cipherText");
                    if (Key == null || Key.Length <= 0)
                        throw new ArgumentNullException("Key");
                    if (IV == null || IV.Length <= 0)
                        throw new ArgumentNullException("IV");
        
                    // Declare the string used to hold
                    // the decrypted text.
                    string plaintext = null;
        
                    // Create an Aes object
                    // with the specified key and IV.
                    using (Aes aesAlg = Aes.Create())
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
        
                                    // Read the decrypted bytes from the decrypting 
                                    // and place them in a string.
                                    plaintext = srDecrypt.ReadToEnd();
                                }
                            }
                        }
        
                    }
        
                    return plaintext;
                }
            }
