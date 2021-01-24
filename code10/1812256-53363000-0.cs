    var query = myList
        .GroupBy(c => c.Name)
        .Select(g => new {
            Name = g.Key,
            _2018_11_01 = g.Where(c => c.Date.Month == 11 && c.Date.Day == 1).Max(c => c.Hour),
            _2018_11_02 = g.Where(c => c.Date.Month == 11 && c.Date.Day == 2).Max(c => c.Hour)
        });
