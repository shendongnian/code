    [WebGet]
    public Product GetProductByID(int productID)
    {
        return this.CurrentDataSource.Products.First(p => p.ID == productID);
    }
    
    [WebGet]
    public IEnumerable<Product> GetCancelledProducts(int productID)
    {
        return this.CurrentDataSource.Products.Where(p.Cancelled);
    }
