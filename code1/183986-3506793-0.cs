    // usage:
    DoStuff(items, Enumerable.Sum);
    DoStuff(items, Enumerable.Max);
    // shared method:
    public IEnumerable<Item> DoStuff(IEnumerable<Item> someItems,
            Func<IEnumerable<decimal>,decimal> aggregate)
    {
        var items = someItems.GroupBy(i => i.Date).Select(
            p => new Item(p.Key, aggregate(p.Select(r=>r.Value))));
        ...
    }
