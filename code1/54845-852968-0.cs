    data
        .GroupBy(x => new
            {
                x.Col1,
                x.Col2,
            })
        .Select(x => x.MaxBy(y => y.Col3)
        .ForEach(x =>
            {
                x.Col5 = x.Col4,
            });
