    static IEnumerable<string> SplitByPair(string input, char[] delimiter)
    {
    	var sep1 = input.IndexOfAny(delimiter);
    	if (sep1 == -1)
    	{
    		yield break;
    	}
    	var sep2 = input.IndexOfAny(delimiter, sep1 + 1);
    	if (sep2 == -1)
    	{
    		yield return input;
    	}
    	else
    	{
    		yield return input.Substring(0, sep2);
    		foreach (var other in SplitByPair(input.Substring(sep1 + 1), delimiter))
    		{
    			yield return other;
    		}
    	}
    }
