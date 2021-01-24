    List<string> productNames = new List<string>();
    foreach (var name in productNames)
    {
    	var product = new Product {Name = name, Color = "something", Body="something body" };
    	DbContext.Products.Add(product);
    }
    DbContext.SaveChanges();
    var result = productNames; 
