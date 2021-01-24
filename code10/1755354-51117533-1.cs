    public class Encrypter : IEncrypter {
        private static readonly Encoding encoding = Encoding.UTF8;
        private readonly EncryptionSettings _encryptionSettings;
    
        public Encrypter(IOptions<EncryptionSettings> encryptionSettings) {
            _encryptionSettings = encryptionSettings.Value;
        }
    
        public string Encrypt(string plainText) {
            //(...)
        }
    
        public string Decrypt(string plainText) {
            //(...)
        }
    
        static byte[] HmacSHA256(String data) {
            //(...)
        }
    }
