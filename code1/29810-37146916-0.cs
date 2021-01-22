    static class Program
    {
        [DllImport( "kernel32.dll", SetLastError = true )]
        static extern bool AllocConsole();
        [DllImport( "kernel32", SetLastError = true )]
        static extern bool AttachConsole( int dwProcessId );
        static void Main(string[] args)
        {
            bool consoleMode = Boolean.Parse(args[0]);
            if (consoleMode)
            {
               if (!AttachConsole(-1))
                  AllocConsole();
               Console.WriteLine("consolemode started");
               // ...
            } 
            else
            {
               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new Form1());
            }
        }
    }
