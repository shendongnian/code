    public class DatabaseExpirationEventArgs : System.EventArgs
    {
    	public DatabaseExpirationEventArgs( List<Guid> expiredKeys )
    	{
    		_expiredKeys = expiredKeys;
    	}
    
    	private List<Guid> _expiredKeys;
    	public List<Guid> ExpiredKeys
    	{
    		get  {  return _expiredKeys;  }
    	}
    }
