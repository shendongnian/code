    List<Product> products = new List<Product>();
    List<Product2> products2 = new List<Product2>();
    
    foreach (var item in Items.mitems)
    {
        Console.WriteLine(item.Name);
        products.Add(((JObject)item).ToObject<Product>());
    }
    
    foreach (var item2 in Items.mitems2)
    {
        Console.WriteLine(item2.Age);
        products2.Add(((JObject)item2).ToObject<Product2>());
    }
