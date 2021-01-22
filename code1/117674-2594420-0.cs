    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("++++Begin to register SHA-256++++");
            Security.Cryptography.Oid2.RegisterSha2OidInformationForRsa();
            Console.WriteLine("++++ End to register SHA-256+++++");
        }
    }
}
