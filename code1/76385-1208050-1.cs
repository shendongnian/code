    IEnumerable<Rule> items = ...;
    foreach(item in items)
    {
        if (item.Operator(item.Field, item.Value))
        { /* do work */ }
    }
