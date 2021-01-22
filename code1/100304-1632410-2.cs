    public static class ApiExtension
    {
        public static string SomeMethod(this ThirdPartyApiClass value)
        {
            string foo = value.SomeCrappyMethodTheProviderGaveUs();
            //do some stuff that the third party api can't do that we need
            return foo;
        }
    }
