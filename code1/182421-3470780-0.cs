    int[] listOfItems = new[] { 4, 2, 3, 1, 6, 4, 3 };
    var duplicates = listOfItems
        .GroupBy(i => i)
        .Where(g => g.Count() > 1)
        .Select(g => g.Key);
    foreach (var d in duplicates)
        Console.WriteLine(d);
