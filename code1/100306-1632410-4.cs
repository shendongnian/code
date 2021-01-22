    public static class ApiExtensionder
    {
        public static MTPAEC(this ThirdPartyApiClass value)
        {
            return new MtpaecExtensionWrapper(value);
        }
    }
    public class MtpaecExtensionWrapper
    {
        private ThirdPartyApiClass Wrapped { get; set; }
        public MtpaecExtensionWrapper(ThirdPartyApiClass wrapped)
        {
            this.Wrapped = wrapped;
        }
        public string SomeMethod()
        {
            string foo = this.Wrapped.SomeCrappyMethodTheProviderGaveUs();
            //do some stuff that the third party api can't do that we need
            return foo;
        }
    }
