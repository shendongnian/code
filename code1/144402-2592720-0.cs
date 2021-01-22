    namespace AESEncryption
    {
        [Guid("[a new guid for the interface]")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IEncrypt        {
            string Encrypt(string data, string filePath);
        }
    
        [Guid("[a new guid for the class]")]
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        public class EncryptDecryptInt : IEncrypt
        {
            public string Encrypt(string data, string filePath)
            {
                // etc.
            }
        }
    }
