    Product product = new Product();    
    product.Name = "Apple";    
    product.Expiry = new DateTime(2008, 12, 28);    
    product.Price = 3.99M;    
    product.Sizes = new string[] { "Small", "Medium", "Large" };    
     
    string json = JavaScriptConvert.SerializeObject(product);
    //{
    //  "Name": "Apple",
    //  "Expiry": new Date(1230422400000),
    //  "Price": 3.99,
    //  "Sizes": [
    //    "Small",
    //    "Medium",
    //    "Large"
    //  ]
    //}   
    
    Product deserializedProduct = JavaScriptConvert.DeserializeObject<Product>(json);
