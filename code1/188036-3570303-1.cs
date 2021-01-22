    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.Security.Cryptography;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program2
        {
            static void Main(string[] args)
            {
                int theId = 1234;   //the ID that's being manipulated
                byte[] byteArray;   //the byte array that stores
    
                //convert the ID to an encrypted string using a Crypto helper class
                string encryptedString = Crypto.EncryptStringAES(theId.ToString(), "mysecret");
                Console.WriteLine("{0} get encrypted as {1}", theId.ToString(), encryptedString);
    
                //convert the encrypted string to byte array
                byteArray = ASCIIEncoding.Default.GetBytes(encryptedString);
                StringBuilder result = new StringBuilder();
    
                //convert each byte to hex and append to a stringbuilder
                foreach (byte outputByte in byteArray)
                {
                    result.Append(outputByte.ToString("x2"));
                }
    
                Console.WriteLine("{0} encrypted is this in hex {1}", encryptedString, result.ToString());
    
                //now reverse the process, and start with converting each char in string to byte
                int stringLength = result.Length;
                byte[] bytes = new byte[stringLength / 2];
    
                for (int i = 0; i < stringLength; i += 2)
                {
                    bytes[i / 2] = System.Convert.ToByte(result.ToString().Substring(i, 2), 16);
                }
    
                //convert the byte array to de-"hexed" string
                string dehexedString = ASCIIEncoding.Default.GetString(bytes);
    
                Console.WriteLine("{0} gets dehexed as {1}", result, dehexedString);
    
                //decrypt the de-"hexed" string using Crypto helper class
                string decryptedString = Crypto.DecryptStringAES(dehexedString, "mysecret");
                Console.WriteLine("{0} got decrypted as {1}", dehexedString, decryptedString);
    
                Console.ReadLine();
            }
        }
    
        public class Crypto
        {
            private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");
    
            /// <summary>
            /// Encrypt the given string using AES.  The string can be decrypted using 
            /// DecryptStringAES().  The sharedSecret parameters must match.
            /// </summary>
            /// <param name="plainText">The text to encrypt.</param>
            /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
            public static string EncryptStringAES(string plainText, string sharedSecret)
            {
                if (string.IsNullOrEmpty(plainText))
                    throw new ArgumentNullException("plainText");
                if (string.IsNullOrEmpty(sharedSecret))
                    throw new ArgumentNullException("sharedSecret");
    
                string outStr = null;                       // Encrypted string to return
                RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.
    
                try
                {
                    // generate the key from the shared secret and the salt
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);
    
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
    
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
                        }
                        outStr = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
                finally
                {
                    // Clear the RijndaelManaged object.
                    if (aesAlg != null)
                        aesAlg.Clear();
                }
    
                // Return the encrypted bytes from the memory stream.
                return outStr;
            }
    
            /// <summary>
            /// Decrypt the given string.  Assumes the string was encrypted using 
            /// EncryptStringAES(), using an identical sharedSecret.
            /// </summary>
            /// <param name="cipherText">The text to decrypt.</param>
            /// <param name="sharedSecret">A password used to generate a key for decryption.</param>
            public static string DecryptStringAES(string cipherText, string sharedSecret)
            {
                if (string.IsNullOrEmpty(cipherText))
                    throw new ArgumentNullException("cipherText");
                if (string.IsNullOrEmpty(sharedSecret))
                    throw new ArgumentNullException("sharedSecret");
    
                // Declare the RijndaelManaged object
                // used to decrypt the data.
                RijndaelManaged aesAlg = null;
    
                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;
    
                try
                {
                    // generate the key from the shared secret and the salt
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);
    
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    // Create the streams used for decryption.                
                    byte[] bytes = Convert.FromBase64String(cipherText);
                    using (MemoryStream msDecrypt = new MemoryStream(bytes))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
    
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
                finally
                {
                    // Clear the RijndaelManaged object.
                    if (aesAlg != null)
                        aesAlg.Clear();
                }
    
                return plaintext;
            }
        }
    
    }
