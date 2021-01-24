    public List<StockViewModel> GetStock()
    {                        
        return StockManagementDatabaseContext.Stocks.Include("Suppliers")
        .Select(a => new StockViewModel
        {
             StockId = a.StockId,
             StockName = a.StockName,
             StockPrice = a.StockPrice,
             //and any other you may wish to include
             SupplierId = a.Suppliers.Select(b => b.SupplierId).FirstOrDefault()
        }).ToList();
    }
