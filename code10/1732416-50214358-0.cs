    var result = await books.Aggregate()
        .Match(b => b.AuthorId == authorId)
        .Group(b => b.AuthorId, g => 
            new {
                AuthorId = g.Key,
                AveragePrice = g.Average(p => p.Price)
            })
        .ToListAsync();
