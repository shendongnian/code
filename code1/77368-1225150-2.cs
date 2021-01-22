    IDictionary<Int32, IList<DataItem>> result =
        new Dictionary<Int32, IList<DataItem>>();
    while (dataSource.DataAvailiable)
    {
        DataItem item = dataSource.ReadItem();
        IList<DataItem> items;
        if (!result.TryGetValue(item.DataSeriesId))
        {
            items = new List<DataItem>();
            result.Add(item.DataSeriesId, items);
        }
        items.Add(item);
    }
