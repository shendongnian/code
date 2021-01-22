    public static class RolesExtension
    {
        public static string[] GetAllNonAdminRoles(this RoleProvider providerInstance)
        {
            return (from role in providerInstance.GetAllRoles()
                    where !role.Equals("Admin", StringComparison.InvariantCultureIgnoreCase)
                    select role).ToArray();
        }
    }
