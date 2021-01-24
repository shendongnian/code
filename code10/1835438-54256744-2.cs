    public static class Extension
    {
    	public static int GetIndex(this string source,Regex regex,int beginIndex=0)
    	{
    		var match = regex.Match(source);
    		while(match.Success)
    		{	
    			
    			if(match.Groups["searchTerm"].Index >= beginIndex)
    				return match.Groups["searchTerm"].Index;
    				
    			match = match.NextMatch();
    		}
    		return -1;
    	}
    }
