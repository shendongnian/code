    class Program
    {
        private static void Main()
        {
            Commander.ShowCommands();
            Console.WriteLine("-------------------");
            Console.WriteLine("Adding 5 commands...");
            Commander.AddCommands("SomeCommand", 5);
            Commander.ShowCommands();
            Console.WriteLine("-------------------");
            Console.WriteLine("Adding 5 more commands...");
            Commander.AddCommands("AnotherCommand", 5);
            Commander.ShowCommands();
            Console.WriteLine("-------------------");
            Console.WriteLine("Done! Press any key to exit...");
            Console.ReadKey();
        }
    }
