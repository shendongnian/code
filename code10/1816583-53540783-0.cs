    public void AddOrUpdate(string userName, int score)
    {
    	string path = "";
    	var newLine = userName + " " + score + Environment.NewLine
    	var lines = File.ReadAllLines(path);
    	var wasUpdated = false;
    	using (var writer = new StreamWriter(path))
    	{
    		foreach (var line in lines)
    		{
    			var foundUserName = line.Substring(0, line.LastIndexOf(' '));
    			if (foundUserName == userName)
    			{
    				writer.Write(newLine);
    				wasUpdated = true;
    			}
    			else
    				writer.Write(line);
    		}
    		if(!wasUpdated)
    			writer.Write(newLine);
    	}
    }
