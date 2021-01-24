    static void Main(string[] args)
    {
        var lines = ReadFile("input.txt");
        List<List<string>> data = new List<List<string>>();
        var firstHeader = false;
        foreach (var line in lines)
        {
            if (!firstHeader && line.StartsWith("Grid-ref="))
            {
                // Found the first header
                firstHeader = true;
                // Let's create a new list and add the header.
                var newList = new List<string> { line };
                data.Add(newList);
            }
            else if (firstHeader && !line.StartsWith("Grid-ref="))
            {
                // Now we're at the number lines to its corresponding list.
                data.Last<List<string>>().Add(line);
            }
            else if (firstHeader && line.StartsWith("Grid-ref="))
            {
                // Found the next header.
                // So we create next list and add the header.
                var newList = new List<string> { line };
                data.Add(newList);
            }
        }
        Console.ReadLine();
    }
    private static List<string> ReadFile(string file)
    {
        var list = new List<string>();
        using (var sr = new StreamReader(file))
        {
            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }
        }
        return list;
    }
