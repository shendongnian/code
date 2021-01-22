	string targetpath = .........;
	Dictionary<string, Dictionary<string, string>> ini = ........;
	StringBuilder sb = new StringBuilder();
	foreach (string section in ini.Keys)
	{
		sb.AppendLine($"[{section}]");
		foreach (string property in ini[section].Keys)
			sb.AppendLine($"{property}={ini[section][property]");
	}
	File.WriteAllText(targetpath, sb.ToString());
