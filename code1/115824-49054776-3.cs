	public static IEnumerable<string> SplitAlpha(string input)
	{
		var words = new List<StringBuilder>{new StringBuilder()};
		for (var i = 0; i < input.Length; i++)
		{
			words[words.Count - 1].Append(input[i]);
			if (i + 1 < input.Length && char.IsLetter(input[i]) != char.IsLetter(input[i + 1]))
			{
				words.Add(new StringBuilder());
			}
		}
		return words.Select(x => x.ToString());
	}
