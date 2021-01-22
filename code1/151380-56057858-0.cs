    Console.Write("This test ");
    Console.BackgroundColor = bTestSuccess ? ConsoleColor.DarkGreen : ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine((bTestSuccess ? "PASSED" : "FAILED"));
    Console.ResetColor();
