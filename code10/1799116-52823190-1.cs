	public static List<Combination> FindCombinations(params int[] values)
    {
		var result = _Combinations
			.Where(c => c.IsSequenceEqual(values))
			.ToList();
		
		return result;
	}
