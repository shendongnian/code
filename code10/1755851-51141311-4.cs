    private static void Main(string[] args)
    {
        var inputs = new List<string>
        {
            "2",
            "2.3",
            "1:2.34",
            "25:32.908",
            "1.2345"
        };
        foreach (var input in inputs)
        {
            Console.WriteLine(ParseMinSecMS(input).ToString("mm\\:ss\\.fFFFFFF"));
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
