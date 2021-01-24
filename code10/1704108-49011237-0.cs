    var startDict = resultsStart
        .GroupBy(r => new {r.SubBook, r.ProductSubType})
        .ToDictionary(g => g.Key, g => g.First());
    var endDict = resultsEnd
        .GroupBy(r => new {r.SubBook, r.ProductSubType})
        .ToDictionary(g => g.Key, g => g.First());
    foreach (var key in startDict.Keys.Union(endDict.Keys)) {
        var hasStart = startDict.TryGetValue(key, out var start);
        var hasEnd = endDict.TryGetValue(key, out var end);
        if (hasStart && hasEnd) {
            ... // Construct the difference with subtraction
        } else if (hasStart) {
            ... // Construct the difference where only the start is present
        } else if (hasEnd) {
            ... // Construct the difference where only the end is present
        }
    }
