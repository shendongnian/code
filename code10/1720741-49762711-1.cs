    public class AppRoleProvider : RoleProvider
    {
        public override string[] GetAllRoles()
        {
            using (var userContext = new UserContext())
            {
                ...  //Do the query with userContext and return some value
            }
        }
        ...
    }
