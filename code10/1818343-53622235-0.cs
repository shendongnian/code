    public static List<string> GetColumnValues(string[] lines, int columnNumber)
    {
        var result = new List<string>();
        Regex regex = new Regex("[ ]{2,}", RegexOptions.None);
        foreach (var line in lines)
        {
            var cleanedLine = regex.Replace(line, " ");
            var columns = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            result.Add(columns[columnNumber-1]);
        }
        return result;
    }
