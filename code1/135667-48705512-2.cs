    var stopwatch = new Stopwatch();
    long abcTotalDuration = 0;
    long abc2TotalDuration = 0;
    string fileInput = "file1.txt";
    string outputFolder = "output";
    for (int i = 0; i < 100; i++)
    {
        string filename1 = Path.Combine(outputFolder, Guid.NewGuid().ToString());
        string filename2 = Path.Combine(outputFolder, Guid.NewGuid().ToString());
        stopwatch.Restart();
        WriteABC(fileInput, filename1);
        stopwatch.Stop();
        abcTotalDuration += stopwatch.ElapsedMilliseconds;
        stopwatch.Restart();
        WriteABC2(fileInput, filename2);
        stopwatch.Stop();
        abc2TotalDuration += stopwatch.ElapsedMilliseconds;
        File.Delete(filename1);
        File.Delete(filename2);
    }
    Console.WriteLine("ABC : " + abcTotalDuration.ToString());
    Console.WriteLine("ABC2: " + abc2TotalDuration.ToString());
    // Just to wake me up :-)
    Console.Beep(800, 1000);
    Console.ReadKey();
