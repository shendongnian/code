    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    public static class Crypto
    {
        private static readonly byte[] IVa = new byte[] { 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x11, 0x11, 0x12, 0x13, 0x14, 0x0e, 0x16, 0x17 };
        public static string Encrypt(this string text, string salt)
        {
            try
            {
                using (Aes aes = new AesManaged())
                {
                    Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(IVa, 0, IVa.Length), Encoding.UTF8.GetBytes(salt));
                    aes.Key = deriveBytes.GetBytes(128 / 8);
                    aes.IV = aes.Key;
                    using (MemoryStream encryptionStream = new MemoryStream())
                    {
                        using (CryptoStream encrypt = new CryptoStream(encryptionStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] cleanText = Encoding.UTF8.GetBytes(text);
                            encrypt.Write(cleanText, 0, cleanText.Length);
                            encrypt.FlushFinalBlock();
                        }
                        byte[] encryptedData = encryptionStream.ToArray();
                        string encryptedText = Convert.ToBase64String(encryptedData);
                        return encryptedText;
                    }
                }
            }
            catch
            {
                return String.Empty;
            }
        }
        public static string Decrypt(this string text, string salt)
        {
            try
            {
                using (Aes aes = new AesManaged())
                {
                    Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(IVa, 0, IVa.Length), Encoding.UTF8.GetBytes(salt));
                    aes.Key = deriveBytes.GetBytes(128 / 8);
                    aes.IV = aes.Key;
                    using (MemoryStream decryptionStream = new MemoryStream())
                    {
                        using (CryptoStream decrypt = new CryptoStream(decryptionStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            byte[] encryptedData = Convert.FromBase64String(text);
                            decrypt.Write(encryptedData, 0, encryptedData.Length);
                            decrypt.Flush();
                        }
                        byte[] decryptedData = decryptionStream.ToArray();
                        string decryptedText = Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
                        return decryptedText;
                    }
                }
            }
            catch
            {
                return String.Empty;
            }
            }
        }
    }
