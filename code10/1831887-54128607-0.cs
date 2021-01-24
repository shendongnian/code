    public void RemoveGrouping()
    {
        if (Data.GroupDescriptions.Count > 0)
            Data.GroupDescriptions.RemoveAt(0);
        Data.SortDescriptions.Clear();
        Data.SortDescriptions.Add(new SortDescription("PropertyName", ListSortDirection.Ascending));
    }
