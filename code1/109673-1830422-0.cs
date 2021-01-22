    static void Main(string[] args)
    {
        string firstArg = args[0];
        Array otherArgs = new string[args.Length - 1];
        Array.ConstrainedCopy(args, 1, otherArgs, 0, args.Length - 1);
        foreach (string foo in otherArgs)
        {
            Console.WriteLine(foo);
        }
    }
