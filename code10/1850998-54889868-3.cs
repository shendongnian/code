    var query = files
        .SelectMany(file => File.ReadAllLines(file))
        .Where(_ => !_.StartsWith("*"))
        .Select(line => new
        {
            Order = line.Substring(32, 7),
            Delta = line.Substring(40, 3),
            Line = new String[] { line }
        })
        .GroupByAdjacent(o => new { o.Order, o.Delta })
        .Select(g => new { g.Key.Order, g.Key.Delta, Lines = g.Select(o => o.Line).ToList() });
