    private static void Main()
    {
        DateTime date;
        var dateFormats = new List<string>
        {
            "13-11-2018 14.32",
            "donderdag 15 november 2018, 14:32",
            "13 nov 2018",
            "14:32 13.11.2018",
            "2018-11-13T16:32:00+2:00"
        };
        DateTime result;
        foreach (var dateFormat in dateFormats)
        {
            if (TryParseAllCultures(dateFormat, out result))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"SUCCESS: {dateFormat.PadRight(36, '.')} {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Unable to parse format: {dateFormat}");
            }
            Console.ResetColor();
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
