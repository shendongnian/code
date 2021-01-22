    using System;
    using System.Security.Cryptography;
    using System.IO;
    public class SimpleAES
    {
        // Change these keys
        private byte[] Key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
        private byte[] Vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 2521, 112, 79, 32, 114, 156 };
        private const int Salt = 8;
        private ICryptoTransform EncryptorTransform, DecryptorTransform;
        private System.Text.UTF8Encoding UTFEncoder;
        public SimpleAES()
        {
            //This is our encryption method
            RijndaelManaged rm = new RijndaelManaged();
            //Create an encryptor and a decryptor using our encryption method, key, and vector.
            EncryptorTransform = rm.CreateEncryptor(this.Key, this.Vector);
            DecryptorTransform = rm.CreateDecryptor(this.Key, this.Vector);
            //Used to translate bytes to text and vice versa
            UTFEncoder = new System.Text.UTF8Encoding();
        }
        /// -------------- Two Utility Methods (not used but may be useful) -----------
        /// Generates an encryption key.
        static public byte[] GenerateEncryptionKey()
        {
            //Generate a Key.
            RijndaelManaged rm = new RijndaelManaged();
            rm.GenerateKey();
            return rm.Key;
        }
        /// Generates a unique encryption vector
        static public byte[] GenerateEncryptionVector()
        {
            //Generate a Vector
            RijndaelManaged rm = new RijndaelManaged();
            rm.GenerateIV();
            return rm.IV;
        }
        /// ----------- The commonly used methods ------------------------------   
        /// Encrypt some text and return a string suitable for passing in a URL.
        public string EncryptString(string TextValue)
        {
            return (TextValue != "") ? Convert.ToBase64String(Encrypt(TextValue)) : "";
        }
        /// Encrypt some text and return an encrypted byte array.
        public byte[] Encrypt(string TextValue)
        {
            //Translates our text value into a byte array.
            Byte[] pepper = UTFEncoder.GetBytes(TextValue);
            // add salt
            Byte[] salt = new byte[Salt];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(salt);
            Byte[] bytes = new byte[2 * Salt + pepper.Length];
            System.Buffer.BlockCopy(salt, 0, bytes, 0, Salt);
            System.Buffer.BlockCopy(pepper, 0, bytes, Salt, pepper.Length);
            crypto.GetNonZeroBytes(salt);
            System.Buffer.BlockCopy(salt, 0, bytes, Salt + pepper.Length, Salt);
            //Used to stream the data in and out of the CryptoStream.
            MemoryStream memoryStream = new MemoryStream();
            /*
             * We will have to write the unencrypted bytes to the stream,
             * then read the encrypted result back from the stream.
             */
            #region Write the decrypted value to the encryption stream
            CryptoStream cs = new CryptoStream(memoryStream, EncryptorTransform, CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.FlushFinalBlock();
            #endregion
            #region Read encrypted value back out of the stream
            memoryStream.Position = 0;
            byte[] encrypted = new byte[memoryStream.Length];
            memoryStream.Read(encrypted, 0, encrypted.Length);
            #endregion
            //Clean up.
            cs.Close();
            memoryStream.Close();
            return encrypted;
        }
        /// The other side: Decryption methods
        public string DecryptString(string EncryptedString)
        {
            return (EncryptedString != "") ? Decrypt(Convert.FromBase64String(EncryptedString)) : "";
        }
        /// Decryption when working with byte arrays.    
        public string Decrypt(byte[] EncryptedValue)
        {
            #region Write the encrypted value to the decryption stream
            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream decryptStream = new CryptoStream(encryptedStream, DecryptorTransform, CryptoStreamMode.Write);
            decryptStream.Write(EncryptedValue, 0, EncryptedValue.Length);
            decryptStream.FlushFinalBlock();
            #endregion
            #region Read the decrypted value from the stream.
            encryptedStream.Position = 0;
            Byte[] decryptedBytes = new Byte[encryptedStream.Length];
            encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
            encryptedStream.Close();
            #endregion
            // remove salt
            int len = decryptedBytes.Length - 2 * Salt;
            Byte[] pepper = new Byte[len];
            System.Buffer.BlockCopy(decryptedBytes, Salt, pepper, 0, len);
            return UTFEncoder.GetString(pepper);
        }
    }
