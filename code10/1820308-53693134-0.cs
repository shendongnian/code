    var aList = new[]
    {
        new SomeObject() { Id = 1, Distance = 3 },
        new SomeObject() { Id = 2, Distance = 5 }
    };
                
    var bList = new[]
    {
        new SomeObject() { Id = 1, Distance = 2 },
        new SomeObject() { Id = 2, Distance = 6 }
    };
    
    var results = aList
        .Union(bList)
        .GroupBy(a => a.Id, a => a)
        .Select(a => a.OrderBy(b => b.Distance).First());
