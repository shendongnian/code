    var result = components[0].Subitems
                 .Join(components[1].Subitems, x => true, y => true, (a, b) => new { Code = a.Code + ":" + b.Code, Price = a.Price + b.Price })
                 .ToList();
    foreach (var item in result)
    {
          Console.WriteLine("Code: " + item.Code + "\t Price: " + item.Price);
    }
    
