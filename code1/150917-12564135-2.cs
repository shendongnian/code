    public class WebConfigEncryption
    {
        private readonly DpapiProtectedConfigurationProvider _provider;
        private readonly MethodInfo _encryptTextMethod;
        private readonly MethodInfo _decryptTextMethod;
    
        public WebConfigEncryption()
        {
            _provider = new DpapiProtectedConfigurationProvider();
            _encryptTextMethod = _provider.GetType().GetMethod("EncryptText", BindingFlags.Instance | BindingFlags.NonPublic);
            _decryptTextMethod = _provider.GetType().GetMethod("DecryptText", BindingFlags.Instance | BindingFlags.NonPublic);
        }
    
        public string Encrypt(string value)
        {
            var encryptedValue = value != null ? (string)_encryptTextMethod.Invoke(_provider, new object[] { value }) : null;
    
            return encryptedValue;
        }
    
        public string Decrypt(string value)
        {
            var decryptedValue = value != null ? (string)_decryptTextMethod.Invoke(_provider, new object[] { value }) : null;
            
            return decryptedValue;
        }
    }
