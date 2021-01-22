    public class MockRoleService : IRolesService
    {
        public new static bool IsUserInRole(string username, string rolename)
        {
            return true;
        }
    }
