    namespace IAMAGoodDeveloper
    {
        public static class Program
        {
            private static readonly int cert;
    
            static void Main(string[] args)
            {
                var myFactory = new MyFactory();
                var secretsProvider = myFactory.GenerateKeyProvider();
                cert = secretsProvider.GetKey("arg");
            }
        }
    }
