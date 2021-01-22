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
            { PortfolioSheetMapping.IssueId,  GetComp(x => x.Product.IssueId) },
            { PortfolioSheetMapping.MarketId, GetComp(x => x.Product.MarketId) },
            { PortfolioSheetMapping.Symbol,   GetComp(x => x.Symbol) },
            // ...
        };
    private static Comparison<Holding> GetComp<T>(Func<Holding, T> selector)
    {
        return (x, y) => Comparer<T>.Default.Compare(selector(x), selector(y));
    }
