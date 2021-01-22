    using System;
    using System.Security.Cryptography;
    using System.IO;
    using System.Text;
    namespace ServiceConsole
    {
        public class Obfuscation
        {
            public static byte[] Encrypt(string data)
            {
                return Encrypt(data, SecurityCredentials.KeyString, SecurityCredentials.IvString);
            }
            public static byte[] Encrypt(string data, string key, string iv)
            {
                return Encrypt(data, key, iv, SecurityCredentials.PaddingString);
            }
            public static byte[] Encrypt(string data, string key, string iv, char paddingCharacter)
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadLeft(32, paddingCharacter).Substring(0, 32));
                byte[] ivBytes = Encoding.UTF8.GetBytes(iv.PadLeft(32, paddingCharacter).Substring(0, 32));
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.BlockSize = 256;
                rijndaelManaged.KeySize = 256;
                MemoryStream memoryStream = new MemoryStream();
                ICryptoTransform iCryptoTransform = rijndaelManaged.CreateEncryptor(keyBytes, ivBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Write);
                StreamWriter streamWriter = new StreamWriter(cryptoStream);
                streamWriter.Write(data);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                byte[] returnBytes = memoryStream.ToArray();
                /// Disposal
                streamWriter.Dispose();
                cryptoStream.Dispose();
                iCryptoTransform.Dispose();
                memoryStream.Dispose();
                rijndaelManaged.Clear();
                ///
                return returnBytes;
            }
            public static string Decrypt(byte[] data)
            {
                return Decrypt(data, SecurityCredentials.KeyString, SecurityCredentials.IvString);
            }
            public static string Decrypt(byte[] data, string key, string iv)
            {
                return Decrypt(data, key, iv, SecurityCredentials.PaddingString);
            }
            public static string Decrypt(byte[] data, string key, string iv, char paddingCharacter)
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadLeft(32, paddingCharacter).Substring(0, 32));
                byte[] ivBytes = Encoding.UTF8.GetBytes(iv.PadLeft(32, paddingCharacter).Substring(0, 32));
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.BlockSize = 256;
                rijndaelManaged.KeySize = 256;
                MemoryStream memoryStream = new MemoryStream(data);
                ICryptoTransform iCryptoTransform = rijndaelManaged.CreateDecryptor(keyBytes, ivBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader(cryptoStream);
                string returnString = streamReader.ReadLine();
                /// Disposal
                streamReader.Dispose();
                cryptoStream.Dispose();
                iCryptoTransform.Dispose();
                memoryStream.Dispose();
                rijndaelManaged.Clear();
                ///
                return returnString;
            }
        }
    }
