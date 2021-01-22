	public static List<int> Bucketize(this IEnumerable<decimal> source, int totalBuckets)
	{
		var min = decimal.MaxValue;
		var max = decimal.MinValue;
		var buckets = new List<int>();
		foreach (var value in source)
		{
			min = Math.Min(min, value);
			max = Math.Max(max, value);
		}
		var bucketSize = (max - min) / totalBuckets;
		foreach (var value in source)
		{
			int bucketIndex = 0;
			if (bucketSize > 0.0)
			{
				bucketIndex = (int)((value - min) / bucketSize);
				if (bucketIndex == totalBuckets)
				{
					bucketIndex--;
				}
			}
			buckets[bucketIndex]++;
		}
		return buckets;
	}
