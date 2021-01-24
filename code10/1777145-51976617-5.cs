    private static void Main()
    {
        for (int i = 0; i < 100; i++)
        {
            TerminalWriteLine(i);                
        }
        Console.ReadLine();
        TerminalWriteLine("There should be 5 blank lines below this", 5);
        Console.ReadLine();
    }
