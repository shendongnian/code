    class Program
    {
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;
            RunApp();
        }
        static void ExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);
            Console.WriteLine("Do you want to Debug?");
            if (Console.ReadLine().StartsWith("y"))
                Debugger.Break();
        }
        static void RunApp()
        {
            throw new Exception();
        }
    }
