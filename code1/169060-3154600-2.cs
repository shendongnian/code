    void Main()  
    {  
    	int count = 100000;  
    	WithRegex(count);  
    	WithSplit(count);  
    	WithIndexOf(count);
    }  
     
    void WithRegex(int count)  
    {  
    	Regex _commaRegex = new Regex(@",", RegexOptions.Compiled);  
    	string[] names = Enumerable.Range(1,count)
            .Select(i => "first,last,middle" + i).ToArray();  
    	List<string> newNames = new List<string>(count);  
     
    	Stopwatch stopWatch = new Stopwatch(); 
    	stopWatch.Start();  
    	foreach (string name in names)  
    	{  
    		string[] split = _commaRegex.Split(name);  
    		StringBuilder sb = new StringBuilder();  
    		sb.Append(split[0]).Append(split[2]).Append(split[1]);  
    		newNames.Add(sb.ToString());  
    	} 
    	stopWatch.Stop(); 
    	stopWatch.Elapsed.Dump("Regex Time");  
    }  
     
    void WithSplit(int count)  
    {  
    	string[] names = Enumerable.Range(1,count)
             .Select(i => "first,last,middle" + i).ToArray();  
    	List<string> newNames = new List<string>(count);  
     
    	Stopwatch stopWatch = new Stopwatch(); 
    	stopWatch.Start();  
    	foreach (string name in names)  
    	{  
    		string[] split = name.Split(',');  
    		StringBuilder sb = new StringBuilder();  
    		sb.Append(split[0]).Append(split[2]).Append(split[1]);  
    		newNames.Add(sb.ToString());  
    	}  
    	stopWatch.Stop(); 
    	stopWatch.Elapsed.Dump("Split Time");  
    }  
    
    void WithIndexOf(int count)  
    {  
    	string[] names = Enumerable.Range(1,count)
            .Select(i => "first,last,middle" + i).ToArray();  
    	List<string> newNames = new List<string>(count);  
     
    	Stopwatch stopWatch = new Stopwatch(); 
    	stopWatch.Start();  
    	foreach (string name in names)  
    	{
    	    /* This approach only works for 2 commas */
    		int firstComma = name.IndexOf(',');
    		int lastComma = name.LastIndexOf(',');
    		
    		string first = name.Substring(0, firstComma);
    		string last = name.Substring(firstComma + 1, lastComma-(firstComma+1));
    		string middle = name.Substring(lastComma + 1);
    		
    		StringBuilder sb = new StringBuilder();  
    		sb.Append(first).Append(middle).Append(last);  
    		
    		newNames.Add(sb.ToString());  
    	} 
    	stopWatch.Stop(); 
    	stopWatch.Elapsed.Dump("IndexOf Time");  
    }  
