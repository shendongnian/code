    int foosPerItem = MyList.First().Foo.Count;
    IOrderedEnumerable<T> ordered = MyList.OrderBy(x => x.foo[0].Value);
    for (int i = 1; i < foosPerItem; i++)
    {
        ordered = ordered.ThenByDescending(x => x.foo[i].Value);
    }
    // added after your comment:
    // ordered = ordered.ThenByDescending(x => x.bar);
