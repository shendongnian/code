	public IEnumerable<long> CreateRange(long start, long count)
	{
		var limit = start + count;
	
		while (start < limit)
		{
			yield return start;
			start++;
		}
	}
