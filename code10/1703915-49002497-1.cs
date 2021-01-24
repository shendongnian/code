    private static void Main()
    {
        // Show info for 2018
        DisplayDayInfo(new DateTime(2018, 01, 01), new DateTime(2019, 01, 01));
        // Draw a separation line
        Console.WriteLine(new string('-', Console.WindowWidth));
        // Show info for April 2018
        DisplayDayInfo(new DateTime(2018, 04, 01), new DateTime(2018, 05, 01));
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
