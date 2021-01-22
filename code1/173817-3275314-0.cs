    var recentItems = from item in GetItems()
                      where item.Timestamp > somedate
                      select item;
    // Nothing gets sent to the server until we try to
    // consume the result in this foreach loop. A single
    // SQL statement is issued that selects all items
    // that are both active and recent.
    foreach (var item in recentItems)
    {
        // Do something with a recent item.
    }
