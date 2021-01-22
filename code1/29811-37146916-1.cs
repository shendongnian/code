    static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program");   //< this ruins everything
            bool consoleMode = Boolean.Parse(args[0]);
            if (consoleMode)
            {
               if (!AttachConsole(-1))
                  AllocConsole();
               Console.WriteLine("consolemode started");   //< this doesn't get displayed on the parent console
               // ...
            } 
            else
            {
               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new Form1());
            }
        }
