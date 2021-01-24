	private IEnumerable<List<T>> Batch<T>(IEnumerable<T> source, int batchSize)
	{
		if (batchSize < 1)
		{
			throw new ArgumentException("Batch size must be at least 1.", nameof(batchSize));
		}
		var batch = new List<T>(batchSize);
		foreach (var item in source)
		{
			batch.Add(item);
			if (batch.Count == batchSize)
			{
				yield return batch;
				batch = new List<T>(batchSize);
			}
		}
		if (batch.Any())
		{
			yield return batch;
		}
	}
