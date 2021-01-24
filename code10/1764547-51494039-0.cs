		var input = @"
    <START>
        <A>message<B>UnknownLengthOfText<BEOF><AEOF>
        <A>message<B>UnknownLengthOfText<BEOF><AEOF>
    <END>";
		var start = "<A>";
		var end = "<AEOF>";
		foreach (var item in ExtractEach(input, start, end))
		{
			Console.WriteLine(item);
		}
	}
	
	public static IEnumerable<string> ExtractEach(string input, string start, string end)
	{
		foreach (var line in input
				 .Split(Environment.NewLine.ToCharArray())
				 .Where(x=> x.IndexOf(start) > 0 && x.IndexOf(start) < x.IndexOf(end)))
		{
			yield return Extract(line, start, end);
		}
	}
	
	
	public static string Extract(string input, string start, string end)
	{
		int startPosition = input.LastIndexOf(start) + start.Length;
		int length = input.IndexOf(end) - startPosition;
		var substring = input.Substring(startPosition, length);
		return substring;
	}
