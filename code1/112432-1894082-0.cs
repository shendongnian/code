    public class Person
    {
    	private IList<Role> _roles;
    	
    	public Person()
    	{
    		this._roles = new List<Role>();
    	}
    	
    	public string Name { get; set; }
    	
    	public void AddRole(Role role)
    	{
    		//implementation
    	}
    	
    	public IEnumerable<Role> Roles
    	{
    		get { return this._roles.AsEnumerable(); }
    	}
    }
