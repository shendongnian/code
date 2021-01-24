    var linePatternsToRemove = new List<String>();
    var resultList = new ConcurrentBag<String>();
    foreach (var line in List)
    {
        var asteriskIndex = line.IndexOf("*");
        if (asteriskIndex != -1)
        {
            linePatternsToRemove.Add(line.Substring(0, asteriskIndex));
        }
    }
    Parallel.ForEach(List, currentLine =>
    {
        Boolean needDeleteLine = false;
        foreach (var pattern in linePatternsToRemove)
        {
            if (currentLine.StartsWith(pattern))
            {
                // If line starts with pattern like "700204" it may be the pattern line itself "700204*" and we don't need to delete it
                // or it can be regular line and we like "70020412" and we need to delete it.
                if (currentLine.Length > pattern.Length && currentLine[pattern.Length] != '*')
                {
                    needDeleteLine = true;
                    break;
                }
            }
        }
        if (!needDeleteLine)
            resultList.Add(currentLine);
    });
