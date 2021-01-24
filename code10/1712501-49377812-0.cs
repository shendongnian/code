    static void Main(string[] args)
    {
        // There must be at least 2 command line arguments...
        if (args == null || args.Length < 2)
        {
            Console.WriteLine("that's not it");
            help();
        }
        else 
        {
            string backupfolder = args[0]; 
            string filetype = args[1];
            checks();
        }
    }
