    static void Main(string[] args)
    {
        var timer = Stopwatch.StartNew();
        var oldestFile = FastDirectoryEnumerator.EnumerateFiles(@"c:\windows\system32")
            .OrderBy(f => f.CreationTime).First();
        timer.Stop();
        Console.WriteLine(oldestFile);
        Console.WriteLine("FastDirectoryEnumerator - {0}ms", timer.ElapsedMilliseconds);
        Console.WriteLine();
        timer.Reset();
        timer.Start();
        var oldestFile2 = new DirectoryInfo(@"c:\windows\system32").GetFiles()
            .OrderBy(f => f.CreationTime).First();
        timer.Stop();
        Console.WriteLine(oldestFile2);
        Console.WriteLine("DirectoryInfo - {0}ms", timer.ElapsedMilliseconds);
        Console.WriteLine("Press ENTER to finish");
        Console.ReadLine();
    }
