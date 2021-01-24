    static async Task Main()
    {
        string[] woodList = { "maple", "ash", "oak", "elm", "birch" };
        foreach (string wood in woodList)
        {
            Treat(wood);
            await Task.Delay(2000);
        }
    }
    private static void Treat(string wood)
    {
        Console.WriteLine($"{DateTime.Now}: treating {wood}");
    }
