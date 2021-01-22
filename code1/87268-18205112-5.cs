    public static IEnumerable<IList<T>> Partition<T>(
        this IEnumerable<T> source,
        int size)
	{
		T[] partition = null;
		var count = 0;
		
		foreach (var t in source)
		{
			if (count == 0)
			{
				partition = new T[size];
			}
			
			partition[count] = t;
			count++;
			
			if (count == size)
			{
				yield return partition;
				count = 0;
			}
		}
		if (count > 0)
		{
			Array.Resize(ref partition, count);
			yield return partition;
		}
	}
