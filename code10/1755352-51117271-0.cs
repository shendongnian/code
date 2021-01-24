    public static class Encrypter
    {
        private static readonly EncryptionSettings _encryptionSettings;
        
        static Encrypter()
        {
            if( IoC.Instance == null ) throw new InvalidOperationException( "IoC must be initialized before static members of Encrypter are used." ); 
            _encryptionSettings = IoC.Instance.GetService<IOptions<EncryptionSettings>>();
        }
    }
