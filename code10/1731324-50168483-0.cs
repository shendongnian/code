    public static IEnumerable<string> MultiEnumerateFiles(string path, string patterns)
    {
    	foreach (var pattern in patterns.Split('|'))
    		foreach (var file in Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories))
    			yield return file;
    }
