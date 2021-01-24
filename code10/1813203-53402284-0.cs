	void Main()
	{
		string[][] StringArray = new string[][] {
		new [] {"Name:", "John", "Jones."},
		new [] {"Date of birth:", "Monday,", "07/11/1989."},
		new [] {"Age:", "29", "Years old."}};
		
		var lines = FormatWhiteSpace(StringArray, Padding: 2);
		
		foreach (var line in lines)
		{
			Console.WriteLine(line);
		}
	}
	
	private IEnumerable<string> FormatWhiteSpace(string[][] StringArray, int Padding)
	{
		var maxLengthDict = StringArray
			.Select(sa => sa.Select((s, i) => new { Column = i, MaxLength = s.Length }))		
			.SelectMany(x => x)
			.GroupBy(x => x.Column)
			.Select(x => new {Column = x.Key, MaxLength = x.Max(y => y.MaxLength)})
			.ToDictionary(x => x.Column, x => x.MaxLength);
			
		return StringArray
			.Select(sa => string.Concat(sa.Select((s, i) => s.PadRight(maxLengthDict[i] + Padding))));
	}
