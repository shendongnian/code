    public static IEnumerable<Product> GetAllProducts()
    {
        using (AdventureWorksEntities db = new AdventureWorksEntities())
        {
            var products = from product in db.Product
                           select product;
    
            return products.ToList();
        }
    }
