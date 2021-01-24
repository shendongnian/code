    private static void Main()
    {
        var input = "20130511";
        var result = GetDate(input);
        Console.WriteLine($"Input: {input}");
        Console.WriteLine($"Year: {result.Year}");
        Console.WriteLine($"Month: {result.Month}");
        Console.WriteLine($"Date: {result.Day}");
        Console.WriteLine($"Dayname: {result.DayOfWeek}");
        Console.WriteLine($"Quarter: {(result.Month - 1) / 4 + 1}");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
