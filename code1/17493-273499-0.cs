    using System;
    using System.IO;
    using System.Security.Cryptography;
    
    namespace RijndaelManaged_Examples
    {
        class RijndaelMemoryExample
        {
            public static void Main()
            {
                try
                {
    
                    string original = "Here is some data to encrypt!";
    
                    // Create a new instance of the RijndaelManaged
                    // class.  This generates a new key and initialization 
                    // vector (IV).
                    RijndaelManaged myRijndael = new RijndaelManaged();
    
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = encryptStringToBytes_AES(original, myRijndael.Key, myRijndael.IV);  
    
                    // Decrypt the bytes to a string.
                    string roundtrip = decryptStringFromBytes_AES(encrypted, myRijndael.Key, myRijndael.IV);
    
                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:   {0}", original);
                    Console.WriteLine("Round Trip: {0}", roundtrip);
    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }
    
            static byte[] encryptStringToBytes_AES(string plainText, byte[] Key, byte[] IV)
            {
                // Check arguments.
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
    
                // Declare the streams used
                // to encrypt to an in memory
                // array of bytes.
                MemoryStream    msEncrypt   = null;
                CryptoStream    csEncrypt   = null;
                StreamWriter    swEncrypt   = null;
    
                // Declare the RijndaelManaged object
                // used to encrypt the data.
                RijndaelManaged aesAlg      = null;
    
                try
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
    
                    // Create the streams used for encryption.
                    msEncrypt = new MemoryStream();
                    csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                    swEncrypt = new StreamWriter(csEncrypt);
    
                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
    
                }
                finally
                {
                    // Clean things up.
    
                    // Close the streams.
                    if(swEncrypt != null)
                        swEncrypt.Close();
                    if (csEncrypt != null)
                        csEncrypt.Close();
                    if (msEncrypt != null)
                        msEncrypt.Close();
    
                    // Clear the RijndaelManaged object.
                    if (aesAlg != null)
                        aesAlg.Clear();
                }
    
                // Return the encrypted bytes from the memory stream.
                return msEncrypt.ToArray();
    
            }
    
            static string decryptStringFromBytes_AES(byte[] cipherText, byte[] Key, byte[] IV)
            {
                // Check arguments.
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
    
                // TDeclare the streams used
                // to decrypt to an in memory
                // array of bytes.
                MemoryStream    msDecrypt   = null;
                CryptoStream    csDecrypt   = null;
                StreamReader    srDecrypt   = null;
    
                // Declare the RijndaelManaged object
                // used to decrypt the data.
                RijndaelManaged aesAlg      = null;
    
                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;
    
                try
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
    
                    // Create the streams used for decryption.
                    msDecrypt = new MemoryStream(cipherText);
                    csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                    srDecrypt = new StreamReader(csDecrypt);
    
                    // Read the decrypted bytes from the decrypting stream
                    // and place them in a string.
                    plaintext = srDecrypt.ReadToEnd();
                }
                finally
                {
                    // Clean things up.
    
                    // Close the streams.
                    if (srDecrypt != null)
                        srDecrypt.Close();
                    if (csDecrypt != null)
                        csDecrypt.Close();
                    if (msDecrypt != null)
                        msDecrypt.Close();
    
                    // Clear the RijndaelManaged object.
                    if (aesAlg != null)
                        aesAlg.Clear();
                }
    
                return plaintext;
    
            }
        }
    }
