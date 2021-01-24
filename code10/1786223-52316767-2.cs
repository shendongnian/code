	var lines = input.Split(new []{"\n"}, StringSplitOptions.RemoveEmptyEntries);
	var output = new StringBuilder();
	for (var i = 0; i < lines.Length; i++)
	{
		if (lines[i].EndsWith(":")) // feel free to also check for the size
		{
			lines[i + 1] =  lines[i] + lines[i + 1];
			continue;
		}
		output.AppendLine(lines[i].Trim()); // remove space before or after a line
	}
