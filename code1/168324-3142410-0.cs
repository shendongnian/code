    List<IItem> items = new List<IItem>();
    items.Add(new Item());
    items.Add(new Composite<Item>());
    items.Add(new Item());
    // Iterate through the items...
    foreach(var item in items)
    {
        item.Foo();
    }
