	var numbers = new[] { 1, 2, 2, 2, 3, 4, 6, 4, 8, 9, 3, 2 };
	var results = 
		numbers
			.Skip(1)
			.Aggregate(
				new[] { numbers.Take(1).ToList() }.ToList(),
				(a, n) =>
				{
					if (a.Last().Last() % 2 != n % 2)
					{
						a.Add(new[] { n }.ToList());
					}
					else
					{
						a.Last().Add(n);
					}
					return a;
				})
			.Where(x => x.Count > 1 && x.First() % 2 == 0)
			.ToList();
