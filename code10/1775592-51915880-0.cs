    using System.Reflection;
    using System.Security.Cryptography;
    namespace _51915147
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cryptoProvider = new TripleDESCryptoServiceProvider();
                var weakEncryptor = cryptoProvider.CreateWeakEncryptor();
            
            }
        }
        public static class TripleDESCryptoServiceProviderExtensions
        {
            public static ICryptoTransform CreateWeakEncryptor(this TripleDESCryptoServiceProvider cryptoProvider, byte[] key, byte[] iv)
            {
                MethodInfo mi = cryptoProvider.GetType().GetMethod("_NewEncryptor", BindingFlags.NonPublic | BindingFlags.Instance);
                object[] Par = { key, cryptoProvider.Mode, iv, cryptoProvider.FeedbackSize, 1 };
                var trans = mi.Invoke(cryptoProvider, Par) as ICryptoTransform;
                return trans;
            }
            public static ICryptoTransform CreateWeakEncryptor(this TripleDESCryptoServiceProvider cryptoProvider)
            {
                return CreateWeakEncryptor(cryptoProvider, cryptoProvider.Key, cryptoProvider.IV);
            }
        }
    }
