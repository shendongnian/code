    static int Main(string[] args)
    {
        // if nothing is being piped in, then exit
        if (!IsPipedInput())
            return 0;
        while (Console.In.Peek() != -1)
        {
            string input = Console.In.ReadLine();
            Console.WriteLine(input);
        }
        return 0;
    }
    private static bool IsPipedInput()
    {
        try
        {
            bool isKey = Console.KeyAvailable;
            return false;
        }
        catch
        {
            return true;
        }
    }
