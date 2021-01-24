    static void Main(string[] args)
    {
        Console.WriteLine("Starting");
        var task = LogDiff();
        Console.WriteLine("Log Diff Initiated");
        /// DO WHATEVER YOU WANT THEN WAIT TASK BELOW
        task.Wait();
    }
    public static async Task LogDiff()
    {
        var results = await GetDiff("Processing Diff");
        Console.WriteLine(results);
    }
    public static async Task<string> GetDiff(string str)
    {
        Console.WriteLine(str);
        await Task.Delay(2000);
        return "Diff processed";
    }
