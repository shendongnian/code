    [TestFixture]
    public class RijndaelHelperTests
    {
        [Test]
        public void UseCase()
        {
            //These two values should not be hard coded in your code.
            byte[] key = {251, 9, 67, 117, 237, 158, 138, 150, 255, 97, 103, 128, 183, 65, 76, 161, 7, 79, 244, 225, 146, 180, 51, 123, 118, 167, 45, 10, 184, 181, 202, 190};
            byte[] vector = {214, 11, 221, 108, 210, 71, 14, 15, 151, 57, 241, 174, 177, 142, 115, 137};
            using (var rijndaelHelper = new RijndaelHelper(key, vector))
            {
                var encrypt = rijndaelHelper.Encrypt("StringToEncrypt");
                var decrypt = rijndaelHelper.Decrypt(encrypt);
                Assert.AreEqual("StringToEncrypt", decrypt);
            }
        }
    }
    public class RijndaelHelper : IDisposable
    {
        Rijndael rijndael;
        UTF8Encoding encoding;
        public RijndaelHelper(byte[] key, byte[] vector)
        {
            encoding = new UTF8Encoding();
            rijndael = Rijndael.Create();
            rijndael.Key = key;
            rijndael.IV = vector;
        }
        public byte[] Encrypt(string valueToEncrypt)
        {
            var bytes = encoding.GetBytes(valueToEncrypt);
            using (var encryptor = rijndael.CreateEncryptor())
            using (var stream = new MemoryStream())
            using (var crypto = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                crypto.Write(bytes, 0, bytes.Length);
                crypto.FlushFinalBlock();
                stream.Position = 0;
                var encrypted = new byte[stream.Length];
                stream.Read(encrypted, 0, encrypted.Length);
                return encrypted;
            }
        }
        public string Decrypt(byte[] encryptedValue)
        {
            using (var decryptor = rijndael.CreateDecryptor())
            using (var stream = new MemoryStream())
            using (var crypto = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
            {
                crypto.Write(encryptedValue, 0, encryptedValue.Length);
                crypto.FlushFinalBlock();
                stream.Position = 0;
                var decryptedBytes = new Byte[stream.Length];
                stream.Read(decryptedBytes, 0, decryptedBytes.Length);
                return encoding.GetString(decryptedBytes);
            }
        }
        public void Dispose()
        {
            if (rijndael != null)
            {
                rijndael.Dispose();
            }
        }
    }
