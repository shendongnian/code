	private static string GetWinner(string[] grid)
	{
		var indexSets = new []
		{
			// Horizontal
			new [] { 0, 1, 2 },
			new [] { 3, 4, 5 },
			new [] { 6, 7, 8 },
			// Vertical
			new [] { 0, 3, 6 },
			new [] { 1, 4, 7 },
			new [] { 2, 5, 8 },
			// Diagonal
			new [] { 0, 4, 8 },
			new [] { 6, 4, 2 }
		};
		foreach (var indices in indexSets)
		{
			var elements = indices.Select(i => grid[i]).ToArray();
			if (!string.IsNullOrEmpty(elements[0]) && elements[0] == elements[1] && elements[0] == elements[2])
			{
				return elements[0];
			}
		}
		return null;
	}
