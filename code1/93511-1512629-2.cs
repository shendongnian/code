	var inputs = from input in htmlDoc.DocumentNode.Descendants("input")
				 where input.Attributes["class"].Value == "box"
				 select input;
	foreach (var input in inputs)
	{
		Console.WriteLine(input.Attributes["value"].Value);
		// John
	}
