    private static void DoSomethingWithExpression(Expression<Func<Product, string>> myExpression)
    {
        var compiled = myExpression.Compile();
    
        using (AdventureWorksDataContext db = new AdventureWorksDataContext())
        {
            var result = db.Products.GroupBy(product => new
                {
                    SubCategoryName = compiled(product),
                    ProductNumber = product.ProductNumber
                });
        }
    }
