	private static IEnumerable<string> ModifyLines(IEnumerable<string> inputLines)
	{
		foreach(var line in inputLines)
		{
			var split = line.Split('|');
			yield return $"{split[0]}|12345";
		}
	}
