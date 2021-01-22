    public class WcfRoleProvider: RoleProvider
    {
        public bool IsUserInRole(string username, roleName)
        {
            bool result = false;
            using(WcfRoleService roleService = new WcfRoleService())
            {
                result = roleService.IsUserInRole(username, roleName);
            }
            return result;
         }
    }
