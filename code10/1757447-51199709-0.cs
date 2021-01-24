    int i = 0;
    foreach (string line in System.IO.File.ReadLines(file, Encoding.UTF8))
    {
        if (++i % 1000 == 0)
            progress.Report(1000);
    }
