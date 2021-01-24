	public static IList<string> SplitChunks(string text, int chunkSize)
	{
		var parts = text.Split(' ');
		return parts.Skip(1).Aggregate(parts.Take(1).ToList(), (a, x) =>
		{
			if ((a.Last() + x).Length > chunkSize)
				a.Add(x);
			else
				a[a.Count - 1] += " " + x;
			return a;
		});
	}
