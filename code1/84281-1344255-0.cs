    using System.Security.Cryptography;
    using System.Text;
    
    namespace UniqueKey
    {
        public class KeyGenerator
        {
            public static string GetUniqueKey(int maxSize)
            {
                char[] chars = new char[62];
                chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                byte[] data = new byte[1];
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
                StringBuilder result = new StringBuilder(maxSize);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length - 1)]);
                }
                return result.ToString();
            }
        }
    }
