	public IQueryable<Part> SearchForParts(string[] query)
	{
		var q = db.Parts.AsQueryable(); 
	
		foreach (string qs in query)
		{
			q = q.Where(x => x.partName.Contains(qs));
		}
	
		return q;
	}
