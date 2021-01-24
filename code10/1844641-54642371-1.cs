    var items = new List<Category>();
    // Create a list of items based off your three lists
    // (this assumes that all three lists have the same count).
    // Ideally, the list of Items would be built instead of the three other lists
    for (int i = 0; i < categories.Count; i++)
    {
        items.Add(new Category
        {
            Name = categories[i],
            Count = count[i],
            Score = score[i]
        });
    }
    // Now you can sort by any property, and then by any other property
    // OrderBy will put smallest first, OrderByDescending will put largest first
    items = items.OrderByDescending(item => item.Score)
        .ThenByDescending(item => item.Count)
        .ToList();
