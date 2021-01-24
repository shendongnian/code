    static void Main(string[] args)
    {
        // There must be at least 2 command line arguments...
        if (args == null || args.Length == 0)
        {
            Console.WriteLine("that's not it");
            help();
        }
        else 
        {
            // You already know there is at least one argument here...
            string backupfolder = args[0]; 
            // Check if there is a second argument, 
            // provide a default value if it's missing
            string filetype = (args.Length > 1) ? args[1] : "" ;
            checks();
        }
    }
