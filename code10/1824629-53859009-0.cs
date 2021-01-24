    interface IDBCaller
    { 
    	IEnumerable<User> RetrieveUserList();
    }
    
    class Implementation1 : IDBCaller
    {
    	public virtual IEnumerable<User> RetrieveUserList()
    	{
		    return new List<User>();
	    }
    }
    
    class Implementation2 : Implementation1
    {
    	public override IEnumerable<User> RetrieveUserList()
    	{
    		return base.RetrieveUserList();
    	}
    }
