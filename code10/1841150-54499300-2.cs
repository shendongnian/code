    private static void Main()
    {
        int temp = 0;
        List<int> numbers =
            GetMultiLineStringFromUser("Paste a multi-line string and press enter: ")
                .SelectMany(i => i.Split()) // Get all the individual entries
                .Where(i => int.TryParse(i, out temp)) // Where the entry is an int
                .Select(i => Convert.ToInt32(i)) // And convert the entry to an int
                .ToList();
        Console.WriteLine("\nYou entered: ");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
        GetKeyFromUser("\nDone!\nPress any key to exit...");
    }
