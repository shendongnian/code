    using System;
    
    class Program {
        static void Main(string[] args) {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            throw new Exception("Kaboom");
        }
    
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e) {
            ConsoleColor colorBefore = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.ForegroundColor = colorBefore;
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
