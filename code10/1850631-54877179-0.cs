    using System;
    using System.Text;
    // Reference assembly 'System.Security'
    using System.Security.Cryptography;
    namespace TestProtectedData
    {
        class Program
        {
            // Encrypt plainText and return a base-64 encoded cipher text
            static string Encrypt(string plainText)
            {
                byte[] plainBytes = UnicodeEncoding.UTF8.GetBytes(plainText);
                byte[] cipherBytes = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(cipherBytes);
            }
    
            // Decrypt a base-64 encoded cipher text and return plain text
            static string Decrypt(string cipherBase64)
            {
                var cipherBytes = Convert.FromBase64String(cipherBase64);
                var plainBytes = ProtectedData.Unprotect(cipherBytes, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);
            }
            static void Main(string[] args)
            {
                // plainTextToEncrypt can be a connection string, user credentials or similar
                var plainTextToEncrypt = "Hello, secret!";
                Console.WriteLine("Plain text: " + plainTextToEncrypt);
                // Getting a base64 encoded string as the encryption result for easy storage
                var cipherBase64 = Encrypt(plainTextToEncrypt);
                // Save the cipherBase64 string into a configuration file or similar
                Console.WriteLine("Encrypted text (base64): " + cipherBase64);
                // When needed, read the cipherBase64 string and decrypt the text
                var plainTextDecrypted = Decrypt(cipherBase64);
                Console.WriteLine("Decrypted text: " + plainTextDecrypted);
                Console.ReadKey();
            }
        }
    }
