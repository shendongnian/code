    IEnumerable<string> FindContinuousKeyInputs(string input, int length = 3)
    {
    	if (length <= 0)
    		throw new ArgumentException(nameof(length));
    		
    	if (input.Length < length)
    		return Enumerable.Empty<string>();
    		
    	var rows = new string[]
    	{
    		@"qwertyuiop[]\",
    		"asdfghjkl;'",
    		"zxcvbnm,./"
    	};
    
    	return Enumerable.Range(0, input.Length - length + 1)
    		.Select(x => input.Substring(x, length))
    		.Where(x => rows.Any(y => y.Contains(x)));
    }
