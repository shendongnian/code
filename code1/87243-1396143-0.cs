	public static IEnumerable<List<T>> Partition<T>(this IList<T> source, Int32 size)
	{
		for (int i = 0; i < (source.Count / size) + (source.Count % size); i++)
			yield return new List<T>(source.Skip(size * i).Take(size));
	}
