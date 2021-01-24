    process.Start();
    while (!process.StandardOutput.EndOfStream)
    {
        string line = process.StandardOutput.ReadLine();
        Console.WriteLine(line);
        // do something with line
    }
    process.WaitForExit();
