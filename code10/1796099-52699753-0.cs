    var line = ReadLine();
    var matches  = Regex.Matches(line, "!SERVER_PATH\\[([\\~a-z\\.\\/]+)\\]");
	foreach(Match match in matches)
	{
		line = line.Replace(match.Value, Server.MapPath(match.Groups[1].Value));
	}
    
