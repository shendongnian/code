	var asteriskLines = new HashSet<string>();
	var otherLines = new List<string>();
	var removeLines = new List<string>();
		
	using (var testFile = new StreamReader("your file path"))
	{
		string nextNumber;
		while ((nextNumber = testFile.ReadLine()) != null)
		{
			if (nextNumber.Contains("*"))
			{
				asteriskLines.Add(nextNumber.Substring(0, nextNumber.IndexOf('*')));
			}
			else
			{
				otherLines.Add(nextNumber);
			}
		}
	}
	foreach (string testNumber in otherLines)
	{
		if (asteriskLines.Any(a => testNumber.StartsWith(a)))
		{
			removeLines.Add(testNumber);
		}
	}
