    void Main()
    {
    	new[] {"a4","a3","a2","a10","b5","b4","b400","1","C1d","c1d2"}.OrderBy(x => x, new NaturalStringComparer()).Dump();
    }
    
    class NaturalStringComparer : IComparer<string>
    {
    	private static readonly Regex _re = new Regex(@"(?<=\D)(?=\d)|(?<=\d)(?=\D)", RegexOptions.Compiled);
    
    	public int Compare(string x, string y)
    	{
    		x = x.ToLower();
    		y = y.ToLower();
    		if (x == y) return 0;
    		var a = _re.Split(x);
    		var b = _re.Split(y);
    		int m = Math.Min(a.Length, b.Length);
    		for(int i=0; i<m; ++i)
    		{
    			int r = PartCompare(a[i], b[i]);
    			if (r != 0) return r;
    		}
    		return x.Length < y.Length ? -1 : 1;
    	}
    
    	private static int PartCompare(string x, string y)
    	{
    		int a, b;
    		if (int.TryParse(x, out a) && int.TryParse(y, out b))
    			return a.CompareTo(b);
    		return x.CompareTo(y);
    	}
    }
