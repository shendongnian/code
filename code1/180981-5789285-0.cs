     IOrderedQueryable<Product> products = context.Products
            .OrderBy(p => p.ListPrice);
    IQueryable<Product> allButFirst3Products = products.Skip(3);
    Console.WriteLine("All but first 3 products:");
    foreach (Product product in allButFirst3Products)
    {
        Console.WriteLine("Name: {0} \t ID: {1}",
            product.Name,
            product.ProductID);
    }
