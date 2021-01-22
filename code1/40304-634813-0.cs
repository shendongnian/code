    public static List<String> Split(this string input, string separator, char escapeCharacter)
    {
    	String word = "";
    	List<String> result = new List<string>();
    	for (int i = 0; i < input.Length; i++)
    	{
    //can also use switch
    		if (input[i] == escapeCharacter)
    		{
    			break;
    		}
    		else if (input[i] == separator)
    		{
    			result.Add(word);
    			word = "";
    		}
    		else
    		{
    			word += input[i];    
    		}
    	}
    	return result;
    }
