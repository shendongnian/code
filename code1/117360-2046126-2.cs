    public static IEnumerable<string> GetrandomLines2()
    {
        string filepath = "..\\..\\data.txt";
        var readTextFile = ReadLines(filepath);
        return readTextFile
            .GroupBy(line => line.Substring(line.Length - 2))
            .SelectMany(s => s.OrderBy(g => Guid.NewGuid()).Take(2));
    }
