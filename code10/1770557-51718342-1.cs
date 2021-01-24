        static void Main(string[] args)
        {
            //Option 1. Not the best: void Main
            //Mixing async and non-async worlds - avoid if possible.
            //See https://stackoverflow.com/questions/9343594/how-to-call-asynchronous-method-from-synchronous-method-in-c
            Task t = MyMethodAsync();
            t.Wait();
        }
        private static async Task MyMethodAsync() {  
            
            IAuth iAuth = new AuthClient();
            Console.WriteLine("\nYour server version:\n");
            string version = await iAuth.GetServerVersionAsync(); //<---- key word 'await'
            Console.WriteLine(version);
            Console.Write("\nPress any key to continue ...");
            Console.ReadKey(true);
        }    
