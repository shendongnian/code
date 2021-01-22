    if (frm.SelectedSortColumn.IsBaseColumn)
    {
        Comparison<Holding> comparison;
        if (!_map.TryGetValue(frm.SelectedSortColumn.BaseColumn, out comparison))
            throw new InvalidOperationException("Can't sort on BaseColumn");
        if (frm.SortAscending)
            pf.Holdings.Sort(comparison);
        else
            pf.Holdings.Sort((x, y) => comparison(y, x));
    }
    // ...
    private static readonly Dictionary<PortfolioSheetMapping, Comparison<Holding>>
        _map = new Dictionary<PortfolioSheetMapping, Comparison<Holding>>
        {
            { PortfolioSheetMapping.IssueId,
              (x, y) => x.Product.IssueId.CompareTo(y.Product.IssueId) },
            { PortfolioSheetMapping.MarketId,
              (x, y) => x.Product.MarketId.CompareTo(y.Product.MarketId) },
            { PortfolioSheetMapping.Symbol,
              (x, y) => x.Symbol.CompareTo(y.Symbol) },
            // ...
        };
