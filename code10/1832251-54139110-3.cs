    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Before adding any commands the list looks like:");
            Commander.ShowCommands();
            Console.WriteLine("-------------------");
            Commander.AddCommands("SomeCommand", 5);
            Console.WriteLine("After adding 5 commands the list looks like:");
            Commander.ShowCommands();
            Console.WriteLine("-------------------");
            Commander.AddCommands("AnotherCommand", 5);
            Console.WriteLine("After adding 5 more commands the list looks like:");            
            Commander.ShowCommands();
            Console.WriteLine("-------------------");
            GetKeyFromUser("Done! Press any key to exit...");
        }
    }
