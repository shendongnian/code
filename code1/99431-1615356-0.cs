    public string Validate(string parms, IEnumerable<ISearchStrategy> searchStrategies)
    {
    	string returnValue = null;
    	
    	foreach(var strategy in searchStrategies)
    	{
    		if(returnValue == null)
    		{
    			returnValue = strategy.Search(parms);
    		}
    	}
    	
    	if(returnValue == null) throw new ApplicationException("ID invalid");
    	return returnValue;
    }
