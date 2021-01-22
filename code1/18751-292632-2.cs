    static IEnumerable<T> GetUniques<T>(IEnumerable<T> things)
	{
		Dictionary<T, int> counts = new Dictionary<T, int>();
		foreach (T item in things)
		{
			int count;
			if (counts.TryGetValue(item, out count))
				counts[item] = ++count;
			else
				counts.Add(item, 1);
		}
		foreach (KeyValuePair<T, int> kvp in counts)
		{
			if (kvp.Value == 1)
				yield return kvp.Key;
		}
	}
