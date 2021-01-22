    var results = source
      .GroupBy(x => x.GroupNumber)
      .OrderBy(g => g.Key)
      .Select(g => new
      {
          GroupNumber = g.Key,
          Result = Validate(g),
          Items = g.ToList()
      })
      .ToList();
