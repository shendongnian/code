    public class RolesService : IRolesService
    {
        public static bool IsUserInRole(string username, string rolename)
        {
            return Roles.IsUserInRole(username, rolename);
        }
    
        // call this guy within the class
        public virtual bool IsUserInRole(string username, string rolename) 
        {
            return IsUserInRole(username, rolename);
        }
    }
    
    public class MockRoleService : RolesService
    {
        public new static bool IsUserInRole(string username, string rolename)
        {
            return true;
        }
    
        public override bool IsUserInRole(string username, string rolename)
        {
            return IsUserInRole(username, rolename); // invokes MockRoleService.IsUserInRole
    
            // or simply
            return true;
        }
    }
