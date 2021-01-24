    var mostPopular = 
        students.GroupBy(s => s,
                         new IgnoreElectiveOrderStudentEqualityComparer())
                .OrderByDescending(g => g.Count())
                .Select(g => new
                {
                    g.Key.ElectiveOne, 
                    g.Key.ElectiveTwo
                })
                .Take(2);
    
