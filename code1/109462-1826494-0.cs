    public IEnumerable<Apple> SearchApples (AppleSearchbag bag)
    {
    	var query = db.Cast<Apple> ();
    	// query will be a Db4objects.Db4o.Linq.IDb4oLinqQuery<Apple>
        if (bag.Color != null)
            query = query.Where (a => a.Color == bag.Color);
    
        return query;
    }
