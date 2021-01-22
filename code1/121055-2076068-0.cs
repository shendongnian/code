    public interface IRolesService
    {
    	bool IsUserInRoleImpl(string username, string rolename);
    }
    
    public abstract class RolesServiceBase<T>  where T : IRolesService, new()
    {
    	protected static T rolesService = new T();
    
    	public static bool IsUserInRole(string username, string rolename)
    	{
    		return rolesService.IsUserInRoleImpl(username, rolename);
    	}
    }
    
    public class RolesService : RolesServiceBase<RolesService>, IRolesService
    {
    	public bool IsUserInRoleImpl(string username, string rolename)
    	{
    		return Roles.IsUserInRole(username, rolename);
    	}
    }
    
    public class MockRoleService : RolesServiceBase<MockRoleService>, IRolesService
    {
    	public bool IsUserInRoleImpl(string username, string rolename)
    	{
    		return true;
    	}
    }
