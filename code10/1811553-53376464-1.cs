    public string ParseWildcardInParameterString(string parameter, string propertyName)
    {
    	string stringWithWildcard = parameter;
    	if (parameter.Contains("%") || parameter.Contains("$"))
    	{
    		stringWithWildcard = parameter;
    		string[] substrings = parameter.Split(new Char[] { '%', '$' }, StringSplitOptions.RemoveEmptyEntries);
    		string[] wildcards = ParseWildcards(parameter);
    		if (substrings.Any())
    		{
    			StringBuilder sb = new StringBuilder();
    			int substringsCount = substrings.Length;
    			for (int i = 0; i < substringsCount; i++)
    			{
    				if (!substrings[i].EndsWith("\\"))
    				{
    					int index = parameter.IndexOf(substrings[i]);
    					if (i < substringsCount - 1)
    					{
    						index = parameter.IndexOf(substrings[i + 1], index + 1);
    						if (index > -1)
    						{
    							string secondPart = wildcards[i].Equals("%") ?
    								$"{propertyName}.IndexOf(\"{substrings[i + 1]}\", {propertyName}.IndexOf(\"{substrings[i]}\") + \"{substrings[i]}\".Length) > -1" :
    								$"{propertyName}.IndexOf(\"{substrings[i + 1]}\", {propertyName}.IndexOf(\"{substrings[i]}\") + \"{substrings[i]}\".Length + 1) == {propertyName}.IndexOf(\"{substrings[i]}\") + \"{substrings[i]}\".Length + 1";
    							sb.Append($"({propertyName}.IndexOf(\"{substrings[i]}\") > -1 And {secondPart}) And ");
    						}
    					}
    				}
    			}
    			stringWithWildcard = sb.Remove(sb.Length - 5, 5).Append(") Or ").ToString();
    		}
    	}
    	return stringWithWildcard;
    }
    
    private string[] ParseWildcards(string parameter)
    {
    	IList<string> wildcards = new List<string>();
    	foreach (var chararcter in parameter.ToCharArray())
    	{
    		if (chararcter.Equals('%') || chararcter.Equals('$'))
    		{
    			wildcards.Add(chararcter.ToString());
    		}
    	}
    	return wildcards.ToArray();
    }
