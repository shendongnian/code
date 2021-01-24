    IEnumerable<string> lines = File.ReadLines(fileName);
    Parallel.ForEach<string>(lines,  line =>
    {
        //Process(line);
    });
