    [EnableQuery]
    public IQueryable<Item> Get()
    {
    	return db.sap_item.AsQueryable();
    }
