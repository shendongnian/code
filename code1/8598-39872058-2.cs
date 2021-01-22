    try
    {
        var exitCode = await StartProcess(
            "dotnet", 
            "--version", 
            10000, 
            @"C:\"
            Console.Out, 
            Console.Out);
        Console.WriteLine($"Process Exited with Exit Code {exitCode}!");
    }
    catch (TaskCanceledException)
    {
        Console.WriteLine("Process Timed Out!");
    }
