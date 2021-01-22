    IEnumerable<IEnumerable<DataItem>> groups = source.Batch(4);
    foreach (IEnumerable<DataItem> group in groups)
    {
        foreach (DataItem item in group)
        {
            ...
        }
    }
