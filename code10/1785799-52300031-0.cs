    if (so == SortOrder.Ascending)
    {                
        DGV.DataSource = Items.OrderBy(x => propertyInfo.GetValue(x, null).ToString(), StringComparer.OrdinalIgnoreCase).ToList();
    }
    else
    {
        DGV.DataSource = Items.OrderByDescending(x => propertyInfo.GetValue(x, null).ToString(), StringComparer.OrdinalIgnoreCase).ToList();
    }
