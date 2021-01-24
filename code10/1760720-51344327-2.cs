    var item = new Demo
    {
      Symbol = "SomeSymbol",
      Expiration = "2019-01-01"
    };
    
    var list = new List<Demo>();
    
    list.Add(item); 
    list.Add(item); // if I comment these lines, then Mongo 2.6.1 returns correct exception
    
    var optionIds = Task.WhenAll(storageService.Save(list)).Result;
