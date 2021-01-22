    public IQueryable<SalesHeader> QueryCurrentSales()
    {
        // You *may* be able to get away with this in the query; I'm not sure
        // what LINQ to SQL would do with it.
        int id = this.Id;
        return context.SalesHeaders
                      .Where(sh => sh.Status == 1 && sh.CustomerId == id);
    }
