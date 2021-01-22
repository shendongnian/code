    IDictionary<string, MyItem> dict = LoadFromDatabase();
    // using a fixed value
    SomeFunc(dict.AsDefaulting(defaultItem));
    // using an independent generator function
    var defaulting = dict.AsDefaulting(() => new MyItem { Id = System.Guid.NewGuid() });
    // using a keydepedent generator function
    var defaulting = dict.AsDefaulting(key => LazyLoadFromDatabase(key));
