    // Shamelessly lifted from http://discuss.itacumens.com/index.php?topic=62872.0, 
    // then converted to C# (http://www.developerfusion.com/tools/convert/vb-to-csharp/) and
    // changed where necessary.
    public class Encryptor
    {
        private static SymmetricAlgorithm _cryptoService = new TripleDESCryptoServiceProvider(); 
        // maybe use AesCryptoServiceProvider instead?
        // vector and key have to match between encryption and decryption
        public static string Encrypt(string text, byte[] key, byte[] vector)
        {
            return Transform(text, _cryptoService.CreateEncryptor(key, vector));
        }
        // vector and key have to match between encryption and decryption
        public static string Decrypt(string text, byte[] key, byte[] vector)
        {
            return Transform(text, _cryptoService.CreateDecryptor(key, vector));
        }
        private static string Transform(string text, ICryptoTransform cryptoTransform)
        {
            MemoryStream stream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write);
            byte[] input = Encoding.Default.GetBytes(text);
            cryptoStream.Write(input, 0, input.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.Default.GetString(stream.ToArray());
        }
    }
