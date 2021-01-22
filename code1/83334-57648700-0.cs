    using var outFile = new StreamReader(outputFile.OpenRead());
    using var expFile = new StreamReader(expectedFile.OpenRead());
    while (!(outFile.EndOfStream || expFile.EndOfStream))
    {
        if (outFile.ReadLine() != expFile.ReadLine())
        {
             return false;
        }
    }
    return (outFile.EndOfStream && expFile.EndOfStream);
