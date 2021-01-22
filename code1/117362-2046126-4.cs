    public static IEnumerable<string> GetrandomLines2(string filePath, int lines)
    {
        return ReadLines(filePath)
            .GroupBy(line => line.Substring(line.Length - 2))
            .SelectMany(s => s.OrderBy(g => Guid.NewGuid()).Take(lines));
    }
