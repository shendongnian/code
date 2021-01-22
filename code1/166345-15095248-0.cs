    static void Main(string[] args)
    {
        if (args.Length == 0) return;
        uint last = (uint)(args.Length - 1);
        // This will eventually throw an IndexOutOfRangeException:
        for (uint i = last; i >= 0; i--)
        {
            Console.WriteLine(args[i]);
        }
    }
