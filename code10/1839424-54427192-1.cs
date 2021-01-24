    var grp = items.GroupBy(g => $"{g.Type}/{g.Price}").Select(s => new
        {
            type= s.Value.First().Type,
            price = s.Value.First().Price,
            count = s.Value.Count()
        }).Where(d => count % GetFactorByType(d.type) == 0).ToList();
