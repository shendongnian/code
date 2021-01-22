    T2 subitem = subsetList.First();
    foreach(T1 item in supersetList)
    {
        while (item.A < subitem.A &&
               subsetList.hasMore())
        {
            subitem = subset.next();
        }
        if (item.A == subitem.A)
        {
            // Make mods here.
        }
    }
