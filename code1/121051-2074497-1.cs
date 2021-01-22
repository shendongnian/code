    public class RolesService : IRolesService
    {
        public static bool IsUserInRole(string username, string rolename)
        {
            return Roles.IsUserInRole(username, rolename);
        }
    
        // call this guy within the class
        protected virtual bool DoIsUserInRole(string username, string rolename) 
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
    
        protected override bool DoIsUserInRole(string username, string rolename)
        {
            return IsUserInRole(username, rolename); // invokes MockRoleService.IsUserInRole
    
            // or simply
            return true;
        }
    }
