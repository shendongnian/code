    var result = data2.GroupBy(n => new { n.Name, n.Date})
            .Select(cl => new Result
            {
                Name = cl.First().Name,
                Date = cl.First().Date,
                Hours = cl.Sum(c => c.Hour),
            }).ToList();
