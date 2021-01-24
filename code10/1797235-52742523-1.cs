    IEnumerable<Item> Merge(IEnumerable<Item> items)
    {
        var lookup = items.ToLookup(item => item.Header);
        foreach (var grouping in lookup)
        {
            var childItems = grouping.Aggregate(
                new List<Item>(),
                (list, item) =>
                {
                    if (item.Items != null)
                        list.AddRange(item.Items);
                    return list;
                });
            yield return new Item
            {
                Header = grouping.Key,
                Items = Merge(childItems)
            };
        }
    }
