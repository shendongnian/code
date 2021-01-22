    // Need an explicitly named type to reference in typeof()
    private class ResultType
    {
         public string SubcategoryName { get; set; }
         public int ProductNumber { get; set; }|
    }
    private static void DoSomethingWithExpression(
        Expression<Func<Product,
        string>> myExpression)
    {
        var productParam = Expression.Parameter(typeof(Product), "product");
        var groupExpr = (Expression<Func<Product, ResultType>>)Expression.Lambda(
            Expression.MemberInit(
               Expression.New(typeof(ResultType)),
               Expression.Bind(
                   typeof(ResultType).GetProperty("SubcategoryName"),
                   Expression.Invoke(myExpression, productParam)),
               Expression.Bind(
                   typeof(ResultType).GetProperty("ProductNumber"),
                   Expression.Property(productParam, "ProductNumber"))),
            productParam);
        using (AdventureWorksDataContext db = new AdventureWorksDataContext())
        {
            var result = db.Products.GroupBy(groupExpr);
        }
    }
