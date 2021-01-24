    static async Task WriteLine(string text) {            
        var delay = Task.Delay(TimeSpan.FromSeconds(1));
        var writeTask = Task.Run(() => Console.WriteLine(text));
        var oldTitle = Console.Title;
        if (await Task.WhenAny(delay, writeTask) == delay) {
            // after one second Console.WriteLine still did not return
            // we are probably in "mark and paste" mode
            Console.Title = "FREEZED!";
        }
        // we cannot ignore our write, have to wait anyway
        await writeTask;
        Console.Title = oldTitle;
    } 
