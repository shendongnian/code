    public class CustomRoleProvider : RoleProvider
    {
        /// <summary>
        /// Gets a list of roles assigned to a particular User
        /// </summary>
        /// <param name="UserID">ID of the User</param>
        /// <param name="context">DbContext</param>
        /// <returns></returns>
        public static List<string> GetUserRoles(int UserID, UserContext context)
        {
            return context.UserList
                          .Where(s => s.UserID == UserID)
                          .SelectMany(s => s.AccessGroup.GroupRoles)
                          .Select(gr => gr.RoleID.ToString()).ToList();
        }
        /// <summary>
        /// Gets a list of roles assigned to a particular user
        /// </summary>
        /// <param name="username">username of the user [or "" for current user]</param>
        /// <param name="context">DbContext</param>
        /// <returns></returns>
        public static List<string> GetUserRoles(string username, UserContext context)
        {
            return context.UserList
                          .Where(s => s.Username == username)
                          .SelectMany(s => s.AccessGroup.GroupRoles)
                          .Select(gr => gr.RoleID.ToString()).ToList();
        }
        //roleName = RoleId; so that only the IDs are stored in session...
        public override bool IsUserInRole(string username, string roleName)
        {
            return GetUserRoles(username, new UserContext()).Contains<string>(roleName);
        }
        public override string[] GetRolesForUser(string username)
        {
            return GetUserRoles(username, new UserContext()).ToArray();
        }
        public override string[] GetAllRoles()
        {
            return new UserContext().UserRoleList.Select(r => r.RoleID.ToString()).ToArray();
        }
        public override bool RoleExists(string roleName)
        {
            return new UserContext().UserRoleList.Where(r => r.RoleID.ToString().Equals(roleName)).Count() > 0;
        }
        public override string ApplicationName
        {
            get { return "Your Application Name"; }
            set { }
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }
    }
