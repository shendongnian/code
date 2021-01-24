    var mostPopular = 
        students.GroupBy(s => s,
                         new ElectiveIgnoreOrderEqualityComparer())
                .OrderByDescending(g => g.Count())
                .Select(g => new
                {
                    g.Key.SelectiveOne, 
                    g.Key.SelectiveTwo
                })
                .Take(2);
    
