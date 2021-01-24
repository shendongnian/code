    private static void Main()
    {
        Console.WriteLine($"Currently the system clock is {GetSystemTimeFormat()} format");
        GetKeyFromUser("Change the format and press any key to try again...");
        Console.WriteLine($"Now the system clock is {GetSystemTimeFormat()} format");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
    private static ConsoleKeyInfo GetKeyFromUser(string prompt)
    {
        Console.Write(prompt);
        var key = Console.ReadKey();
        Console.WriteLine();
        return key;
    }
