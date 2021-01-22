    List<Product> products = new List<Product>();
    products.Add(new Product { CategoryName = "Tops", Color = "Red" });
    products.Add(new Product { CategoryName = "Tops", Color = "Gree" });
    products.Add(new Product { CategoryName = "Trousers", Color = "Red" });
    var query = (IEnumerable<Product>)products;
    query = query.Where(p => p.CategoryName == "Tops");
    query = query.Where(p => p.Color == "Red");
    foreach (Product p in query)
    	Console.WriteLine(p.CategoryName + " / " + p.Color);
    Console.ReadLine();
