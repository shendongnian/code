    private object _syncRoot = new object();
    private List<Guid>  _objectChanges = new List<Guid>();
    public event EventHandler<DatabaseExpirationEventArgs> ExpirationFired;
    ...
    public void UpdateExpirations()
    {
    	lock ( _syncRoot )
    	{
    		DataTable dt = GetExpirationsFromDb();
    		List<Guid> keys = new List<Guid>();
    		foreach ( DataRow dr in dt.Rows )
    		{
    			Guid key = (Guid)dr[0];
    			keys.Add(key);
    			_objectChanges.Add(key);
    		}
    
    		if ( ExpirationFired != null )
    			ExpirationFired(this, new DatabaseExpirationEventArgs(keys));
    	}
    }
