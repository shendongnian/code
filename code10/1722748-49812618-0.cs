	private IEnumerable<IEnumerable<T>> Batch<T>(IEnumerable<T> input, int batchSize)
	{
		List<T> items = new List<T>();
		foreach (var item in input)
		{
			items.Add(item);
			if (items.Count == batchSize)
			{
				yield return items;
				items = new List<T>();
			}
		}
		if (items.Count > 0)
		{
			yield return items;
		}
	}
