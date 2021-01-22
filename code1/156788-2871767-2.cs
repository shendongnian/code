    class Program
    {
        static void Main()
        {
            ParseCommnandLineArguments();
        }
        static void ParseCommnandLineArguments()
        {
            var args = Environment.GetCommandLineArgs();
            foreach(var arg in args)
                Console.WriteLine(arg);
        }
    }
CommandLineArguments.exe -q a -b r
