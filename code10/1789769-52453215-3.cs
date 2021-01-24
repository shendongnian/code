     static void Main(string[] args)
            {
                Console.WriteLine("Resolve sample");
                var unity = DependencyConfiguration.Config();
                var lstOfTypes = unity.Resolve<ListOfTypes>();
    
                lstOfTypes.PrintHandlers();
    
                Console.ReadLine();
            }
