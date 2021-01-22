    using (sw = new StreamWriter(Console.OpenStandardOutput())
    {
        sw.AutoFlush = true;
        Console.SetOut(sw);
        ...
    }
    StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
    standardOutput.AutoFlush = true;
    Console.SetOut(standardOutput);
