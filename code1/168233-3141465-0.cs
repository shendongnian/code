        private static readonly Dictionary<PortfolioSheetMapping, Func<Holding, object>> sortingOperations = new Dictionary<PortfolioSheetMapping, Func<Holding, object>>
        {
            {PortfolioSheetMapping.Symbol, p => p.Symbol},
            {PortfolioSheetMapping.Quantitiy, p => p.Quantitiy},
            // more....
        };
        public static List<Holding> SortHoldings(this IEnumerable<Holding> holdings, SortOrder sortOrder, PortfolioSheetMapping sortField)
        {
            if (sortOrder == SortOrder.Decreasing)
            {
                return holdings.OrderByDescending(sortingOperations[sortField]).ToList();
            }
            else
            {
                return holdings.OrderBy(sortingOperations[sortField]).ToList();                
            }
        }
