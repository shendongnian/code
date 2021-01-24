    public int mostCommonSalary(List<Person> collection, params string [] types)
    {
    	foreach (var type in types)
    	{
    		if (collection.Any(x => x.Type == type)
    		{
    			return collection.Where(x => x.Type == type)
    					.GroupBy(pr => pr.Salary)
    					.OrderByDescending(g => g.Count())
    					.Select(x => x.Key)
    					.FirstOrDefault();
    		}
    	}	
    
    	// nothing found
    	return -1;
    }
