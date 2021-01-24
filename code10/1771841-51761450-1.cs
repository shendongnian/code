    List<string> productNames = new List<string>();
    List<string> holdProducts = new List<string>();
    foreach (var name in productNames)
    {
    	var product = new Product {Name = name, Color = "something", Body="something body" };
    	DbContext.Products.Add(product);
    	holdProducts.Add(product);
    }
    DbContext.SaveChanges();
    var result = holdProducts; 
    
