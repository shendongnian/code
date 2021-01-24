    var result = await db.Model
            .GroupBy(x => x.Age)
            .Select(g => new {
                Age = g.Key, 
                Count = g.Count(),
            })
            .ToListAsync();
