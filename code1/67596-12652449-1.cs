    Product product = new Product();
    product.Name = "Apple";
    product.Expiry = new DateTime(2008, 12, 28);
    product.Price = 3.99M;
    product.Sizes = new string[] { "Small", "Medium", "Large" };
     
    string json = JsonConvert.SerializeObject(product);
