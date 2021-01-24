    var wordArray = new List<String[]>();               // Declare wordArray
	while ((line2 = streamReader2.ReadLine()) != null)
	{
		if (line2.Any(Char.IsDigit) && line2.Any(Char.IsLetter)) // If line2 contains letter and digit
			wordArray.Add(line2.Split());  // Add the line split with whitespace to wordArray
	}
