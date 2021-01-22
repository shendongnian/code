    public class EncryptionModule : StandardModule
    {
        public override void Load()
        {
            Bind<IStringEncryptor>().To<TripleDESStringEncryptor>();
        }
    }
