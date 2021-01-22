    public static int StringToInt(string encodedString, char[] baseChars) {
    	int sourceBase = baseChars.Length;
    
    	var dict = baseChars
    		.Select((c, i) => new { Value = c, Index = i })
    		.ToDictionary(x => x.Value, x => x.Index);
    
    	return encodedString.ToCharArray()
    		// Get a list of positional weights in descending order, calcuate value of weighted position
    		.Zip(Enumerable.Range(0,encodedString.Length).Reverse(), (f,s) => dict[f] * (int)Math.Pow(sourceBase,s)) 
    		.Sum();
    }
