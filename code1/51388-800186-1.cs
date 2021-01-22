        var collectionOfThings = new[] 
            {
                new Thing { Id = 1, Type = "typeX" },
                new Thing { Id = 2, Type = "typeY" },
                new Thing { Id = 3, Type = "typeZ" },
                new Thing { Id = 4, Type = "typeX" }
            };
        var query = (from thing in collectionOfThings
                     group thing by thing.Type == "typeX" into grouped
                     //orderby grouped.Key descending
                     select new
                     {
                         IsTypeX = grouped.Key,
                         Items = grouped.ToList()
                     }).ToList();
        var typeXs = query.Find(x => x.IsTypeX).Items;
        var notTypeXs = query.Find(x => !x.IsTypeX).Items;
