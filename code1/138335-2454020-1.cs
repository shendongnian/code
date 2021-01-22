	public static IEnumerable<T> Every<T>(this IEnumerable<T> source, int count)
	{
		int cnt = 0;
		foreach(T item in source)
		{
			cnt++;
			if (cnt == count)
			{
				cnt = 0;
				yield return item;
			}
		}
	}
