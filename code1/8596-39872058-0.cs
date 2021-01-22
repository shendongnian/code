    try
    {
        var exitCode = await StartProcess(
            @"C:\",
            "dotnet", 
            "--version", 
            10000, 
            Console.Out, 
            Console.Out);
        Console.WriteLine($"Process Exited with Exit Code {exitCode}");
    }
    catch (TaskCanceledException)
    {
        Console.WriteLine("Process Timed Out");
    }
