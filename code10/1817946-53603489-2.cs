    void Main()
    {
    	var rnd = new Random();
    	var strings = Enumerable.Range(0, 1000000).Select(x => x.ToString() + (rnd.Next(2) == 0 ? " " : "")).ToArray();
    	
    	var results = new [] { new { source = 0, elapsed = TimeSpan.Zero } }.Take(0).ToList();
    	
    	for (int i = 0; i < 100; i++)
    	{
    		
    		var sw = Stopwatch.StartNew();
    		var trimmed0 = strings.Select(x => SafeTrim0(x)).ToArray();
    		sw.Stop();
    		results.Add(new { source = 0, elapsed = sw.Elapsed });
    		
    		sw = Stopwatch.StartNew();
    		var trimmed1 = strings.Select(x => SafeTrim1(x)).ToArray();
    		sw.Stop();
    		results.Add(new { source = 1, elapsed = sw.Elapsed });		
    	}
    
    	results.GroupBy(x => x.source, x => x.elapsed.TotalMilliseconds).Select(x => new { x.Key, Average = x.Average() }).Dump();
    }
    
    public static string SafeTrim1(string str)
    {
        return str?.Trim() ?? string.Empty;
    }
    
    public static string SafeTrim0(object str) 
    {
        if ( str == null || str == DBNull.Value )
          return string.Empty;
        else
          return str.ToString().Trim();
    }
