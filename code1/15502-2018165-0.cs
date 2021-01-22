    using CLRConsole = System.Console;
    
    namespace ExtensionMethodsDemo
    {
        public static class Console
        {
            public static void WriteLine(string value)
            {
                CLRConsole.WriteLine(value);
            }
    
            public static void WriteBlueLine(string value)
            {
                System.ConsoleColor currentColor = CLRConsole.ForegroundColor;
    
                CLRConsole.ForegroundColor = System.ConsoleColor.Blue;
                CLRConsole.WriteLine(value);
    
                CLRConsole.ForegroundColor = currentColor;
            }
    
            public static System.ConsoleKeyInfo ReadKey(bool intercept)
            {
                return CLRConsole.ReadKey(intercept);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteBlueLine("This text is blue");   
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
    
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }
    }
