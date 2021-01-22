    // path is string
    int skip = 300;
    StreamReader sr = new StreamReader(path);
    using (var lineReader = new LineReader(sr)) {
        IEnumerable<string> lines = lineReader.Skip(skip);
        foreach (string line in lines) {
            Console.WriteLine(line);
        }
    }
