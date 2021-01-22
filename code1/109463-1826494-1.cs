    public IQueryable<Apple> SearchApples (AppleSearchbag bag)
    {
    	var query = db.AsQueryable<Apple> ();
    	// query will be a System.Linq.IQueryble<Apple>
        if (bag.Color != null)
            query = query.Where (a => a.Color == bag.Color);
    
        return query;
    }
