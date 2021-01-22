    public static StringBuilder BulkReplace(this StringBuilder source, IDictionary<string, string> replacementMap)
    {
    	if (source.Length == 0 || replacementMap.Count == 0)
    	{
    		return source;
    	}
    	string replaced = Regex.Replace(source.ToString(), String.Join("|", replacementMap.Keys.Select(Regex.Escape).ToArray()), m => replacementMap[m.Value], RegexOptions.IgnoreCase);
    	return source.Clear().Append(replaced);
    }
