    private static ICollection<List<Log>> GroupIds(List<Log> logs)
    {
    	var emptyIdsGroup = new List<Log>();
    	var idSetById = new Dictionary<string, HashSet<string>>();
    	var mergeSets = new HashSet<HashSet<string>>();
    	foreach (var log in logs)
    	{
    		if (log.Ids.Count == 0)
    		{
    			emptyIdsGroup.Add(log);
    			continue;
    		}
    		HashSet<string> idSet = null;
    		mergeSets.Clear();
    		foreach (var id in log.Ids)
    		{
    			HashSet<string> mergeSet;
    			if (idSetById.TryGetValue(id, out mergeSet))
    				mergeSets.Add(mergeSet);
    			else
    			{
    				if (idSet == null) idSet = new HashSet<string>();
    				idSet.Add(id);
    				idSetById.Add(id, idSet);
    			}
    		}
    		foreach (var mergeSet in mergeSets)
    		{
    			if (idSet == null)
    				idSet = mergeSet;
    			else
    			{
    				foreach (var id in mergeSet)
    				{
    					idSet.Add(id);
    					idSetById[id] = idSet;
    				}
    			}
    		}
    	}
    
    	var groups = logs
    		.Where(log => log.Ids.Count > 0)
    		.GroupBy(log => idSetById[log.Ids.First()], (key, group) => group.ToList())
    		.ToList();
    
    	if (emptyIdsGroup.Count > 0) groups.Add(emptyIdsGroup);
    
    	return groups;
    }
