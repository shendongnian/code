    private static void DoSomethingWithExpression(Expression<Func<Product, string>> myExpression)
    {
        var productParam = myExpression.Parameters[0];
        ConstructorInfo constructor = ...; // Get c'tor for return type
        var keySelector = Expression.Lambda(
                              Expression.New(constructor,
                                  new Expression[] {
                                      productParam.Body,
                                      ... // Expressions to init other members
                                  },
                                  new MethodInfo[] { ... }), // Setters for your members
                              new [] { productParam });
        using (AdventureWorksDataContext db = new AdventureWorksDataContext())
        {
            var result = db.Products.GroupBy(keySelector);
            // ...
        }
    }
