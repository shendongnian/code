	var lines = input.Split(new []{"\n"}, StringSplitOptions.RemoveEmptyEntries);
	var output = new StringBuilder();
	for (var i = 0; i < lines.Length; i++)
	{
		if (lines[i].EndsWith(":"))
		{
			lines[i + 1] =  lines[i] + lines[i + 1];
			continue;
		}
		output.AppendLine(lines[i]);
	}
