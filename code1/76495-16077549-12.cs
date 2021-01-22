	// instantiate the database as object
	var nw = new NorthWind();
	
	// select product
	var product = nw.Products.Single(p => p.ProductName == "Chai");
	// 1. modify the price
	product.UnitPrice = 2.33M;
	
	// 2. store a new category
	var c = new Category();
	c.Category = "Example category";
	c.Description = "Show how to persist data";
	nw.Categories.Add(c);
	
	// Save changes (1. and 2.) to the Northwind database
	nw.SaveChanges();
