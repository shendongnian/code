    public class Owner
    {
    	public List<Owned> OwnedList { get; set; }
    }
    
    public class Owned
    {
    	private Owner _owner;
    
    	public Owner ParentOwner
    	{
    		get
    		{
    			if ( _owner == null )
    				_owner = GetParentOwner(); // GetParentOwner() can be any method for getting the parent object
    			return _owner;
    		}
    	}
    }
