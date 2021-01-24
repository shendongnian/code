	int[] denominations = new [] { 20, 10, 5, 1 };
	List<int> result =
		denominations
			.Aggregate(new { Result = new List<int>(), Remainder = 161 }, (a, x) =>
			{
				a.Result.Add(a.Remainder / x);
				return new { a.Result, Remainder = a.Remainder % x };
			})
			.Result;
