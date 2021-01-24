    var lines = new List<string> { words[0] };
	var lineNum = 0;
    for(int i = 1; i < words.Length; i++)
	{
		if(lines[lineNum].Length + words[i].Length + 1 <= 20)
			lines[lineNum] += " " + words[i];
		else
		{
			lines.Add(words[i]);
			lineNum++;
		}
	}
