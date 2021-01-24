    public class CustomConfigProvider : ConfigurationProvider
    {
        public CustomConfigProvider() { }
 
        public override void Load()
        {
            Data = MyEncryptUtils.DecryptConfiguration();
        }
    }
