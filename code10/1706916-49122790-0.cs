	var array = new[] { 1, 4, 7, 3, -3, -4, -1, 4, 2, 1 };
	var descending_subarrays =
		array
			.Skip(1)
			.Aggregate(new [] { array.Take(1).ToList() }.ToList(), (a, x) =>
			{
				if (a.Last().Last() > x)
				{
					a.Last().Add(x);
				}
				else
				{
					a.Add(new [] { x }.ToList());
				}
				return a;
			})
			.OrderByDescending(x => x.Count)
			.ToList();
