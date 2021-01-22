    public static IEnumerable<Product> AllProducts
    {
        get {
            using (AdventureWorksEntities db = new AdventureWorksEntities()) {
                var products = from product in db.Product
                               select product;
    
                return products;
            }
        }
    }
