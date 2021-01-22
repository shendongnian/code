    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Program called without arguments");
        }
        else
        {
            Console.WriteLine("Program received this arguments:");
            foreach (string arg in args)
            {
                Console.WriteLine("\t{0}", arg);
            }
        }
        // .. do other stuff
    }
