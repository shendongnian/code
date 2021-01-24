    public interface ICustomPrincipal : System.Security.Principal.IPrincipal
    {
        string FirstName { get; set; }
     
        string LastName { get; set; }
    	
    	int CompanyId { get;set; }
    }
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
     
        public CustomPrincipal(string username)
    	{
    		this.Identity = new GenericIdentity(username);
    	}
     
    	public bool IsInRole(string role)
    	{
    		return Identity != null && Identity.IsAuthenticated && 
    		   !string.IsNullOrWhiteSpace(role) && Roles.IsUserInRole(Identity.Name, role);
    	}
    
    	public string FirstName { get; set; }
    
    	public string LastName { get; set; }
    
    	public string FullName { get { return FirstName + " " + LastName; } }
    	
    	public int CompanyId { get;set; }
    }
    
    public class CustomPrincipalSerializedModel
    {
        public int Id { get; set; }
     
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
    	
    	public int CompanyId { get;set; }
    }
