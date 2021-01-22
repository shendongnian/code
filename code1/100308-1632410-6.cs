    public static class ApiExtensionder
    {
        public static MTPAEC(this ThirdPartyApiClass value)
        {
            return new MtpaecExtensionWrapper(value);
        }
    }
    public class MtpaecExtensionWrapper
    {
        private ThirdPartyApiClass wrapped;
        public MtpaecExtensionWrapper(ThirdPartyApiClass wrapped)
        {
            this.wrapped = wrapped;
        }
        public string SomeMethod()
        {
            string foo = this.wrapped.SomeCrappyMethodTheProviderGaveUs();
            //do some stuff that the third party api can't do that we need
            return foo;
        }
    }
