    if (itemData.DataSource != null && itemData.DataSource.Description == nameof(DataSource.CustomDataTable))
    {
        
        itemData.Id = originalTable.Max(x => x.Id) + 1;
        itemData.SortOrder = tableSortOrder;
        newTable.Add(itemData); <-- Here you keep adding the same item
    }
