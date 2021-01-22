    // The list.Count part is in case the list starts off with
    // fewer than 3 elements
    for (int i = 0; i < 3 && list.Count > 0; i++)
    {
        var oldest = list.MinBy(x => x.Date);
        list.Remove(oldest);
    }
