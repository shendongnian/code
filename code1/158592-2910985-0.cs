    public Dictionary<string, Stream> GetData(string[] paths)
    {
    	Dictionary<string, Stream> data = new Dictionary<string, Stream>();
    	foreach (string path in paths)
    	{
    		data[path] = new FileStream(path, FileMode.Open);		
    	}
    	
    	return data;
    }
