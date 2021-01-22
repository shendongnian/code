    void Main()
    {
    	var file = @"C:\.... some.xsd";
    	Do(file);
    	files.Dump();
    	
    	("xsd.exe \"" + string.Join("\" \"", files) + "\" /classes").Dump();
    }
    
    private void Do(string file)
    {
    	file = file.ToLower();
    	
    	var dir = Path.GetDirectoryName(file);
    	var contents = File.ReadAllText(file);
    	var regex = @"schemaLocation=""(.*?)""";
    	
    	if (files.Contains(file))
    	{
    		return;
    	}
    	
    	files.Add(file);
    	
    	var toProcess = Regex.Matches(contents, regex).OfType<Match>().Select (m => m.Groups[1].Value).Select (m => 
    	{
    		if (Path.IsPathRooted(m))
    		{
    			return m;
    		}
    		else
    		{
    			return Path.GetFullPath(Path.Combine(dir, m));
    		}
    	}).Select (m => m.ToLower()).Where (m => !files.Contains(m)).ToList();
    	
    	foreach (var nested in toProcess)
    	{
    		Do(nested);
    	}
    }
    private List<string> files = new List<string>();
