    var listWithPositionsToDel = new ConcurrentBag<String>();
    var linePatternsToRemove = new List<String>();
    foreach (var line in List)
    {
        if (line.IndexOf("*") != -1)
        {
            linePatternsToRemove.Add(line.Substring(0, line.IndexOf("*")));
        }
    }
    Parallel.ForEach(List, (pos) =>
    {
        Boolean needDeleteLine = linePatternsToRemove.Any(pattern => pos.StartsWith(pattern));
        if (needDeleteLine)
        {
            listWithPositionsToDel.Add(pos);
        }
    }); 
