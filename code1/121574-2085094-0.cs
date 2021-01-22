    public static IEnumerable<string> permute(string s){
    	if (s.Count() > 1)
    		return from c in s
    			   from p in permute(s.Remove(s.IndexOf(c), 1))
    			   select string.Format("{0}{1}", c, p);
    	else
    		return new string[] { s };
    }
