    private static string FindMatchingPattern(string sample1, string sample2, bool forwardDirection)
    {
    	string shorter = string.Empty;
    	string longer = string.Empty;
    
    	if (sample1.Length <= sample2.Length)
    	{
    		shorter = sample1;
    		longer = sample2;
    	}
    	else
    	{
    		shorter = sample2;
    		longer = sample1;
    	}
    
    	StringBuilder matchingPattern = new StringBuilder();
    	StringBuilder wordHolder = new StringBuilder();
    
    	if (forwardDirection)
    	{
    		for (int idx = 0; idx < shorter.Length; idx++)
    		{
    			if (shorter[idx] == longer[idx])
    				if (shorter[idx] == ' ')
    				{
    					matchingPattern.Append(wordHolder + " ");
    					wordHolder.Clear();
    				}
    				else if (shorter[idx] == '.') // . is a Regex special char
    					wordHolder.Append(@"\.");
    				else
    					wordHolder.Append(shorter[idx]);
    			else
    				break;
    		}
    	}
    	else
    	{
    		while (true)
    		{
    			if (shorter[shorter.Length - 1] == longer[longer.Length - 1])
    			{
    				if (shorter[shorter.Length - 1] == ' ')
    				{
    					matchingPattern.Insert(0, " " + wordHolder);
    					wordHolder.Clear();
    				}
    				else if (shorter[shorter.Length - 1] == '.')
    					wordHolder.Insert(0, @"\.");
    				else
    					wordHolder.Insert(0, shorter[shorter.Length - 1]);
    
    				shorter = shorter.Remove(shorter.Length - 1, 1);
    				longer = longer.Remove(longer.Length - 1, 1);
    			}
    			else
    			{
    				break;
    			}
    		}
    	}
    
    	return matchingPattern.ToString();
    }
