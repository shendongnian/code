    public IList<IEntryGrain> SortEntries()
    {
    	return State.Entries.OrderBy(GetComparator)
                            .ToList();
    }
    private decimal GetComparator(IEntryGrain x)
    {
    	var task = x.GetState();
    	task.Wait();
    	
    	if(task.IsFaulted)
    		throw new Exception($"could not get the state: {task.Exception}", task.Exception);
    		
    	return task.Result;
    }
