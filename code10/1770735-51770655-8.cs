    private static ICollection<List<Log>> GroupIds(List<Log> logs)
    {
    	var emptyIdsGroup = new List<Log>();
    	var idSetById = new Dictionary<string, IdSet>();
    	foreach (var log in logs)
    	{
    		if (log.Ids.Count == 0)
    		{
    			emptyIdsGroup.Add(log);
    			continue;
    		}
    		IdSet idSet = null;
    		foreach (var id in log.Ids)
    		{
    			IdSet mergeSet;
    			if (!idSetById.TryGetValue(id, out mergeSet))
    			{
    				if (idSet == null) idSet = new IdSet();
    				idSet.Ids.Add(id);
    				idSetById.Add(id, idSet);
    			}
    			else if (idSet == null)
    				idSet = mergeSet;
    			else if (idSet.Ids != mergeSet.Ids)
    			{
    				// Merge the set with less elements into the set with more elements
    				if (idSet.Ids.Count >= mergeSet.Ids.Count)
    				{
    					idSet.Ids.UnionWith(mergeSet.Ids);
    					mergeSet.Ids = idSet.Ids;
    				}
    				else
    				{
    					mergeSet.Ids.UnionWith(idSet.Ids);
    					idSet.Ids = mergeSet.Ids;
    					idSet = mergeSet;
    				}
    			}
    		}
    	}
    
    	var groups = logs
    		.Where(log => log.Ids.Count > 0)
    		.GroupBy(log => idSetById[log.Ids.First()].Ids, (key, group) => group.ToList())
    		.ToList();
    
    	if (emptyIdsGroup.Count > 0) groups.Add(emptyIdsGroup);
    
    	return groups;
    }
