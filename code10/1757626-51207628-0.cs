	public static IEnumerable<IEnumerable<T>> ZipMultiple<T>(this List<List<T>> source)
	{
		var counts = source.Select(s => s.Count).Distinct();
		if (counts.Count() != 1)
		{
			throw new ArgumentException("Lists aren't the same length");
		}
		for (var i = 0; i < counts.First(); i++)
		{
			var item = new List<T>();
			for (var j = 0; j < source.Count; j++)
			{
				item.Add(source[j][i]);
			}
			yield return item;
		}
	}
