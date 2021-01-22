    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    using System.Web;
    namespace EncryptData
    {
        class EncryptData
        {
        private static readonly Encoding ASCII_ENCODING = new System.Text.ASCIIEncoding();
        private static string md5(string text)
        {
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCII_ENCODING.GetBytes(text))).Replace("-", "").ToLower();
        }
        public abstract string nonce();
        public abstract string salt();
        public readonly string EncryptedData;
        public EncryptData(string message)
        {
            // set up encrytion object
            RijndaelManaged aes192 = new RijndaelManaged();
            aes192.KeySize = 192;
            aes192.BlockSize = 192;
            aes192.Padding = PaddingMode.None;
            aes192.Mode = CipherMode.CBC;
            aes192.Key = ASCII_ENCODING.GetBytes(md5(SECRET_KEY));
            aes192.GenerateIV();
            string localSalt = salt();
            string localNonce = nonce();
            // form the string for encrypting
            // and put into byte array
            string textToEncrypt = localSalt + message+ localNonce;
            byte[] plainTextBytes = ASCII_ENCODING.GetBytes(textToEncrypt);
            // encrypt the data            
            ICryptoTransform encryptor = aes192.CreateEncryptor();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            cs.Write(plainTextBytes, 0, plainTextBytes.Length);
            // convert our encrypted data from a memory stream into a byte array.
            byte[] cypherTextBytes = ms.ToArray();
            // close memory stream
            ms.Close();
            byte[] combined = null;
            // combine data and convert to byte array
            combined = CombinedData(localSalt, aes192.IV, cypherTextBytes);
            // url encode data once converted to base64 string
            EncryptedData = HttpUtility.UrlEncode(base64CombinedData(combined), ASCII_ENCODING);
        }
        public byte[] CombinedData(string salt, byte[] IV, byte[] cypherTextBytes)
        {
            // convert salt string into byte array
            byte[] saltBytes = ASCII_ENCODING.GetBytes(salt);
            // catenate all the byte arrays into one
            // set up dest byte array with required size
            byte[] rv = new byte[saltBytes.Length + IV.Length + cypherTextBytes.Length];
            // copy in each byte array
            Buffer.BlockCopy(saltBytes, 0, rv, 0, saltBytes.Length);
            Buffer.BlockCopy(IV, 0, rv, saltBytes.Length, IV.Length);
            Buffer.BlockCopy(cypherTextBytes, 0, rv, saltBytes.Length + IV.Length, cypherTextBytes.Length);
            return rv;
        }
        public string base64CombinedData(byte[] rv)
        {
            return Convert.ToBase64String(rv);
        }
    }
    }
