        public class RolesService
        {
            static RolesService()
            {
                isUserInRoleFunction = IsUserInRole;
            }
            public static delegate bool IsUserInRoleFunctionDelegate(string username, string rolename);
            public static IsUserInRoleFunctionDelegate isUserInRoleFunction { get; set; }
            private bool IsUserInRole(string username, string rolename) 
            {
                return Roles.IsUserInRole(username, rolename);
            }
        }
