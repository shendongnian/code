    private static void Main()
    {
        var todaysCustomDateString = GetCustomDateString(DateTime.Today);
        Console.WriteLine($"Today is the {todaysCustomDateString}");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
