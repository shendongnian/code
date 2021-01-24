    private static void Main()
    {
        var input = GetMultiLineStringFromUser("Paste a multi-line string and press enter: ");
        Console.WriteLine("\nYou entered: ");
        foreach(var line in input)
        {
            Console.WriteLine(line);
        }
        GetKeyFromUser("\nDone!\nPress any key to exit...");
    }
