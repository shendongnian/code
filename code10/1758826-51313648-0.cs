    var test = _repository.DbSet().
            .AsEnumerable()
            .Select(t => new CustomClass
            {
                Count = t.Count.ToString(),
            }).ToList();
