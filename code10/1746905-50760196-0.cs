	var dbTableList =
		nonGrouped
			.GroupBy(x => new
			{
				x.Id,
				x.Col1,
				x.Col2
			})
			.Select(x => new MyDbTable
			{
				Id = x.Key.Id,
				VALUE = x.Sum(y => y.Value),
				Col1 = x.Key.Col1,
				Col2 = x.Key.Col2
			})
			.GroupBy(x => new
			{
				x.Col1,
				x.Col2
			})
			.SelectMany(xs => xs.Take(1))
			.ToList();
