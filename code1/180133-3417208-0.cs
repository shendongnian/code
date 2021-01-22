    var objects = new []
        {
            new { Name = "Bill", Id = 1 },
            new { Name = "Bob", Id = 5 },
            new { Name = "David", Id = 9 }
        };
    
    for (var i = 0; i < 10; i++)
    {
        var match = objects.SingleOrDefault(x => x.Id == i);
        
        if (match != null)
        {
            Console.WriteLine("i: {0}  match: {1}", i, match.Name);
        }
    }
