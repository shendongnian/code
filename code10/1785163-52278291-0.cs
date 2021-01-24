    var product = p;
    if (cust.Products.Exists(prod => prod.ProductId == p.ProductId))
    {
	   product = cust.Products.Find(prod => prod.ProductId == p.ProductId);
    }
    else
    {
	   cust.Products.Add(p);
    }
    if (product.Items == null)
	   product.Items = new List<Item>();
    product.Items.Add(i);
