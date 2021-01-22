	public static IEnumerable<string> SplitAlpha(string input)
	{
		var words = new List<string> { string.Empty };
		for (var i = 0; i < input.Length; i++)
		{
			words[words.Count-1] += input[i];
	        if (i + 1 < input.Length && char.IsLetter(input[i]) != char.IsLetter(input[i + 1]))
			{
				words.Add(string.Empty);
			}
		}
		return words;
	}
