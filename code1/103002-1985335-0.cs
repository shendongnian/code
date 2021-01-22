    var example = new[]
        {
            new { Count = 1, Name = "a" }, new { Count = 2, Name = "b" },
            new { Count = 2, Name = "c" }, new { Count = 2, Name = "c" }
        };
            
    var result = from x in example
                    select new 
                    {
                        x.Name, 
                        Sum = (from y in example 
                               where y.Count.Equals(2) 
                                   && y.Name==x.Name
                               select y.Count).Sum()
                    };
    var distinct = result.Distinct().ToList();
