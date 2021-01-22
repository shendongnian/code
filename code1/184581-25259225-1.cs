    IQueryable<Product> q = context.Products.ToList();
    var SelectedProducts = new List<Product>
    {
      new Product{Id=23},
      new Product{Id=56}
    };
    ...
    // Collecting set of product id's    
    var selectedProductsIds = SelectedProducts.Select(p => p.Id).ToList();
    
    // Filtering products
    q = q.WhereIn(c => c.Product.Id, selectedProductsIds);
