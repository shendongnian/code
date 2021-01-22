    var column = PortFolioSheetMapping.MarketId.ToString();
    if (frm.SelectedSortColumn.IsBaseColumn)
    {
        if (frm.SortAscending)
             pf.Holdings = pf.Holdings.OrderBy(column).ToList();
        else
             pf.Holdings = pf.Holdings.OrderByDescending(column).ToList();
    }
