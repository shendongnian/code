    var removeLines = new ConcurrentBag<string>();
...
    Parallel.ForEach(otherLines, (testNumber, state, index) =>
    {
        if (asteriskLines.Any(a => testNumber.StartsWith(a, StringComparison.Ordinal)))
        {
            removeLines.Add(testNumber);
        }
    });
