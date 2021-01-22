    using ItemGroupingByDate = IGrouping<DateTime, Item>;
    using AggregateItems = Func<Func<Item, decimal>, decimal>;
    public IEnumerable<Item> DoOtherStuff(
        IEnumerable<Item> someItems,
        Func<ItemGroupingByDate, AggregateItems> getAggregateForGrouping
        )
    {
        var items = someItems.GroupBy(i => i.Date)
            .Select(p => new Item(p.Key, getAggregateForGrouping(p)(r => r.Value)));
        // ...
    }
