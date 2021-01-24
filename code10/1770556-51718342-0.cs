        static async Task Main(string[] args) // <-- not 'void', but 'async Task' 
        {
            //Option 1. The best: async Task Main
            IAuth iAuth = new AuthClient();
            Console.WriteLine("\nYour server version:\n");
            var version = await iAuth.GetServerVersionAsync(); //<---- key word 'await'
            Console.WriteLine(version);
            Console.Write("\nPress any key to continue ...");
            Console.ReadKey(true);
        }
