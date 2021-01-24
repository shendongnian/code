    var data = new[]
    {
        new { Id = 12, TagID = 3, ItemContent = "Low" },
        new { Id = 13, TagID = 3, ItemContent = "Low, Medium" },
        new { Id = 13, TagID = 4, ItemContent = "Low, Medium" },
    };
    var search = new List<int>(new[] { 3, 4 });
    var result = data
        // group the items on ItemContent
        .GroupBy(item => item.ItemContent, d => d, (k, g) => new { ItemContent = k, g })
        // only select groups when all searchitems are found in a list of TagID
        .Where(groupedItem => search.All(i => groupedItem.g.Select(y => y.TagID).Contains(i)))
        // select the result
        .Select(groupedItem => groupedItem);
    foreach (var r in result)
        Console.WriteLine(r.ItemContent);
    Console.ReadLine();
