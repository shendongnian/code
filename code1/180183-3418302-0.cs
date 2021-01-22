    foreach (var item in bizItems.items)
    {
        Console.WriteLine(item.BusinessLocation.City);
        foreach (var profile in item.BusinessProfile)
        {
            Console.WriteLine(profile.Name);
        }
        foreach (var product in item.Products)
        {
            Console.WriteLine(product.Price);
        }
        Console.WriteLine(item.Count);
        Console.WriteLine();
    }
