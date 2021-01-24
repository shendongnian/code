    public void AddOrUpdate(string userName, int score)
    {
    	string path = "";
    	var newLine = userName + " " + score;
    	var lines = File.ReadAllLines(path);
    	var wasUpdated = false;
    	using (var writer = new StreamWriter(path))
    	{
    		foreach (var line in lines)
    		{
    			var foundUserName = line.Substring(0, line.LastIndexOf(' '));
    			if (foundUserName == userName)
    			{
    				writer.WriteLine(newLine);
    				wasUpdated = true;
    			}
    			else
    				writer.WriteLine(line);
    		}
    		if(!wasUpdated)
    			writer.WriteLine(newLine);
    	}
    }
