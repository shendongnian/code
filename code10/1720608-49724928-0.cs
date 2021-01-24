    private static void Main()
    {
        var colTimes = new List<string>
        {
            "01:00", "02:10", "07:40", "03:45", "02:45"
        };
        var totalTime = new TimeSpan(0, 0, 0);
        foreach(string colTime in colTimes)
        {
            totalTime = totalTime.Add(TimeSpan.Parse(colTime));
        }
        Console.WriteLine($"Times: {string.Join(", ", colTimes)}");
        Console.WriteLine($"\nThe total is: {totalTime.ToString(@"hh\:mm")}");
        GetKeyFromUser("\nDone!\nPress any key to exit...");
    }
