    public IEnumerable<Item> DoStuff(
      IEnumerable<Item> someItems,
      Func<IGrouping<DateTime,decimal>,Item> reduce) {
      var items = someItems.GroupBy(i => i.Date).Select(reduce);
      ...
    }
    
    DoStuff(someItems, p => p.Sum(r => r.Value));
    DoStuff(someItems, p => p.Max(r => r.Value));
