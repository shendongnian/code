    static class StringExtensions
    {
    	public static string Slice(this string input, string option)
    	{
    		var opts = option.Trim().Split(':').Select(s => s.Length > 0 ? (int?)int.Parse(s) : null).ToArray();
    		if (opts.Length == 1)
    			return input[opts[0].Value].ToString();		// only one index
    		if (opts.Length == 2)
    			return Slice(input, opts[0], opts[1], 1);		// start and end
    		if (opts.Length == 3)
    			return Slice(input, opts[0], opts[1], opts[2]);		// start, end and step
    		throw new NotImplementedException();
    	}
    	public static string Slice(this string input, int? start, int? end, int? step)
    	{
    		int len = input.Length;
    		if (!step.HasValue)
    			step = 1;
    		if (!start.HasValue)
    			start = (step.Value > 0) ? 0 : len-1;
    		else if (start < 0)
    			start += len;
    		if (!end.HasValue)
    			end = (step.Value > 0) ? len : -1;
    		else if (end < 0)
    			end += len;
    		string s = "";
    		if (step < 0)
    			for (int i = start.Value; i > end.Value && i >= 0; i+=step.Value)
    				s += input[i];
    		else 
    			for (int i = start.Value; i < end.Value && i < len; i+=step.Value)
    				s += input[i];
    		return s;
    	}
    }
