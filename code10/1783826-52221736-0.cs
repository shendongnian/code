    void Main()
    {
    	var data = @"username: @newbie
    				password: 1g1d91dk
    				uid: 961515154
    				message: blablabla
    				date: 30 / 06 / 18
    				mnumer: 854762158";
    
    	var regex = new Regex(@"^\s*(?<key>[^\:]+)\:\s*(?<value>.+)$");
    	var dic = data
    		.AsLines()
    		.Select(line => regex.Match(line))
    		.Where(m => m.Success)
    		.Select(m => new { key = m.Groups["key"].Value, value = m.Groups["value"].Value })
    		.ToDictionary(x => x.key, x => x.value);
    	Console.WriteLine(dic["uid"]);
    }
    
    public static class StringEx
    {
    	public static IEnumerable<string> AsLines(this string input)
    	{
    		StringReader sr = new StringReader(input);
    		string line;
    		while ((line = sr.ReadLine()) != null)
    		{
    			yield return line;
    		}
    
    	}
    }
