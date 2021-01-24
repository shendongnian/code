    List<string> productNames = new List<string>();
    List<Product> holdProducts = new List<Product>();
    foreach (var name in productNames)
    {
    	var product = new Product {Name = name, Color = "something", Body="something body" };
    	DbContext.Products.Add(product);
    	holdProducts.Add(product);
    }
    DbContext.SaveChanges();
    var result = holdProducts; 
   
