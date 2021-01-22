    public interface IRolesService
    {
        bool IsUserInRole(string username, string rolename);
    }
    public class RolesService : IRolesService
    {
        public bool IsUserInRole(string username, string rolename)
        {
            return Roles.IsUserInRole(username, rolename);
        }
    }
    
    public class MockRoleService : IRolesService
    {
        public bool IsUserInRole(string username, string rolename)
        {
            return true;
        }
    }
