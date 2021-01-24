        static void Main(string[] args)
        {
            Task.Run(DoSomeHeavyInitializationAsync);
            // do something else...
            Console.ReadLine();
        }
