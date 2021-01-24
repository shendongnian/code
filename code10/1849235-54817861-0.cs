    // Fill our list
    var list = new List<Item>
    {
        new Item {Code = 1, Price = 2},
        new Item {Code = 2, Price = 2},
        new Item {Code = 1, Price = 2}
    };
    
    // Perform LINQ
    var result = list.GroupBy(x => x.Code).Select(x => new
    {
        Code = x.Key,
        Sum = x.Sum(z => z.Price)
    }).ToList();
