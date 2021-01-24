    .Select(x => new MyDbTable
    {
        Id = x.Key.Id,
        VALUE = x.Sum(y => y.Value),
        Col1 = x.Key.Col1,
        Col2 = x.Key.Col2
    }).ToList().Distinct(new MyDbTableComparer());
