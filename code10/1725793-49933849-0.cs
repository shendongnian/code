	System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[A-Z ]+");
	var str = "Text 123 and more Text THIS IS MORE TEXT";
	var matches = regex.Matches(str);
	foreach (var match in matches)
	{
		Console.WriteLine(match);	
	}
