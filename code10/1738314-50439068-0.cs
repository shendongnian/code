    static void Main(string[] args)
    {
        string input = "";
        Task.Run(async () => { input = await System.Console.In.ReadToEndAsync(); });
    }
