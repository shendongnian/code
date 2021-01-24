    public int mostCommonSalaryGeneral<T>(List<Person> collection, 
                                          Func<Person, T> filterFunc,  params T[] types)
    {
    	foreach (var type in types)
    	{
    		if (collection.Any(x=> filterFunc(x).Equals(type)))
    		{
    			return collection.Where(x=> filterFunc(x).Equals(type))
    					.GroupBy(pr => pr.Salary)
    					.OrderByDescending(g => g.Count())
    					.Select(x => x.Key)
    					.FirstOrDefault();
    		}
    	}
    	// nothing found
    	return -1;
    }
