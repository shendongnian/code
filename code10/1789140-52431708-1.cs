    private static volatile bool cancelRequested = false;
    public static void Main(string[] args)
    {
        Console.CancelKeyPress += new ConsoleCancelEventHandler(ExitConsole);
        while (!cancelRequested)
        {
            // here your program will continue a WHOLE WHILE loop until user requests exit by 
            // pressing either the C console key (C) or the Break key 
            // (Ctrl+C or Ctrl+Break).
             
            UserInput #1;
            UserInput #2;
            UserInput #3;
        }
    }
    static void ExitConsole(object sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = true;
        cancelRequested = true;
    }
