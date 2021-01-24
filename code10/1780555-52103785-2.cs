    public static List<string> GetData(string allData)
    {
        var newLine = "0A";
        var space = "20-";
        var endText = "-03";
        var data = new List<string>();
        if (string.IsNullOrWhiteSpace(allData)) return data;
        var lines = allData.Split(new[] { newLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var lastSpace = line.LastIndexOf(space);
            if (lastSpace == -1) continue;
            var endOfText = line.IndexOf(endText, lastSpace);
            if (endOfText == -1) continue;
            var start = lastSpace + space.Length;
            var length = endOfText - start;
            data.Add(line.Substring(start, length).Trim('-'));
        }
        return data;
    }
