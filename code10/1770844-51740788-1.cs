    public static async Task Working()
    {
        Console.WriteLine("Please wait, the program is running");
        // either return a completed Task, or await for it (there is a difference!
        await Task.CompletedTask;
        // or:
        return Task.CompletedTask; // do not declare async in this case
    }
    public static async Task Takingtime()
    {
        Console.WriteLine("This Program started");
        //Use Task.Delay instead of Sleep
        await Task.Delay(TimeSpan.FromSeconds(1);   // improved readability
        Console.WriteLine("The Program finished");
    }
