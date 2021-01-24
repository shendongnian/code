    public void GetPatternsToList()
    {
    	var files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
    
    	var patterns = new HashSet<string>();
    
    	foreach (var file in files)
    	{
    		var splitFileName = file.Split('-').Skip(1).Take(3);
    		var joinedFileName = string.Join("-", splitFileName);
    
    		if(!string.IsNullOrEmpty(joinedFileName)
    			patterns.Add(joinedFileName);
    	}
    
    	listBox1.DataSource = patterns;
    }
