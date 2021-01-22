    void Main()
    {
        int count = 100000;
    	WithRegex(count);
    	WithSplit(count);
    }
    
    void WithRegex(int count)
    {
    	Regex _commaRegex = new Regex(@",", RegexOptions.Compiled);
    	string[] names = Enumerable.Range(1,count).Select(i => "first,last,middle").ToArray();
    	List<string> newNames = new List<string>(count);
    	
    	DateTime start = DateTime.Now;
    	foreach (string name in names)
    	{
    		string[] split = _commaRegex.Split(name);
    		StringBuilder sb = new StringBuilder();
    		sb.Append(split[0]).Append(split[2]).Append(split[1]);
    		newNames.Add(sb.ToString());
    	}
    	(start - DateTime.Now).Dump("Regex Time");
    }
    
    void WithSplit(int count)
    {
    	string[] names = Enumerable.Range(1,count).Select(i => "first,last,middle").ToArray();
    	List<string> newNames = new List<string>(count);
    	
    	DateTime start = DateTime.Now;
    	foreach (string name in names)
    	{
    		string[] split = name.Split(',');
    		StringBuilder sb = new StringBuilder();
    		sb.Append(split[0]).Append(split[2]).Append(split[1]);
    		newNames.Add(sb.ToString());
    	}
    	(start - DateTime.Now).Dump("Split Time");
    	newNames.Count().Dump();
    }
