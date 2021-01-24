    private static void WriteToConsole(int Lemmings)
    {
        int i = Lemmings;
        while (i > 0)
        {
            Console.WriteLine("loop {0}", i);
            i = i - 1; // Decrease i, no need for recursion here
        }
    }
