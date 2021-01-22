    public IEnumerable<Item> DoOtherStuff(IEnumerable<Item> someItems,
        Func<
            IGrouping<DateTime, Item>,
            Func<Func<Item, decimal>, decimal>
            > aggregateForGrouping
        )
    {
        var items = someItems.GroupBy(i => i.Date)
            .Select(p => new Item(p.Key, aggregateForGrouping(p)(r => r.Value)));
        // ...
    }
    DoOtherStuff(someItems, p => p.Max);
