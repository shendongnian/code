    using LinqKit;
    // ...
    Expression<Func<Product, bool>> expression = product => product.ListPrice > 0;
    var result = db.ProductSubcategories
        .AsExpandable() // This is the magic that makes it all work
        .Select(
            subCategory => new
            {
                Name = subCategory.Name,
                ProductArray = subCategory.Products
                    // Products isn't IQueryable, so we must call expression.Compile
                    .Where(expression.Compile())
            })
        .First();
    Console.WriteLine("There are {0} products in SubCategory {1} with ListPrice > 0."
        , result.ProductArray.Count()
        , result.Name
        );
