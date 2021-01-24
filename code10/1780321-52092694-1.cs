    static List<string> megreLists(List<string> lst1, List<string> lst2)
    {
    	List<string> result = new List<string>();
    
    	if (lst1.Count == lst2.Count)
    	{
    		for (int i = 0; i < lst1.Count; i++)
    		{
    			if (string.IsNullOrWhitespace(lst1[i]) && lst1[i].Trim() == lst2[i].Trim())
    			{
    				result.Add(lst1[i]);
    			}
    			else if (string.IsNullOrWhitespace(lst1[i]) && lst1[i].Trim() != lst2[i].Trim())
    			{
    				result.Add(lst1[i]);
    			}
    			else if (string.IsNullOrWhitespace(lst2[i]) && lst1[i].Trim() != lst2[i].Trim())
    			{
    				result.Add(lst2[i]);
    			}
    		}
    	}
    
    	return result;
    }
    
    
    
    var result = megreLists(megreLists(list01, list02), list03);
