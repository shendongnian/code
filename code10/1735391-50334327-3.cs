    public async Task<AbstractPagedList<Product>>GetProductsWithQuery(ProductQuery qp)
    {
        var products = DorianContext.Products
            .Include(p => p.Category)
            .Include(p => p.PriceOffers)
            .AsQueryable();
        foreach(var filter in qp.Filters)
        {
            products = products.Where(filter);
        }
        return await PagedList<Product>.CreateAsync(products, qp.PageNumber, qp.PageSize);
    }
