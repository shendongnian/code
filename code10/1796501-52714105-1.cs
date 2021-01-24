        static void Main(string[] args)
        {
            Task.Run(DoSomeHeavyInitializationAsync);
            Console.ReadLine();
        }
