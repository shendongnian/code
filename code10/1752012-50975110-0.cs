    namespace KMSSecurity
    {
        public class Common : IDisposable
        {
            public Common();
            static Common()
            {
                Instance = new Common();
            }
            public static string AppName { get; set; }
            public static string ConnectionString { get; set; }
            public static Common Instance { get; }
            public KMSSecurityContext Context { get; protected set; }
            public bool ChangeAppPermissionForUser(Guid appId, string userName, bool grant);
            public bool ChangeCategoryPermissionForUser(int categoryId, string userName, bool grant);
            public bool ChangePassword(string userName, string oldPassword, string newPassword);
            public void ChangePasswordQuestionAndAnswer(string username, string password, string passwordquestion, string passwordanswer);
            public bool ChangePermissionForUser(Guid roleId, int categoryid, string permissionName, string userName, bool grant);
            public bool ChangePermissionForUser(Guid roleId, string permissionName, string userName, bool grant);
            public bool ChangeRolePermissionForUser(Guid roleId, string userName, bool grant);
            public void CopyUserPermissions(string userNameFrom, string userNameTo, Guid appId);
            public void CopyUserPermissions(string userNameFrom, string userNameTo, string applicationName);
            public Guid CreateApplication(string appName);
            public int CreateCategory(string appName, string roleName, string categoryName, string categoryDesc, int displayOrder);
            public bool CreatePermission(string permissionName, string permissionDesc, string permissionHelpText, int displayOrder, int categoryId);
            public Guid? CreateRole(string appName, string roleName, string roleDescription);
            public MembershipUser CreateUser(string userName, string email, string passwordQuestion, string passwordAnswer);
            public MembershipUser CreateUser(string userName, string passWord, string email, string passwordQuestion, string passwordAnswer);
            public UserPermissions CreateUserPermissions();
            public UserPermissions CreateUserPermissions(string userName);
            public UserPermissions CreateUserPermissions(string userName, List<Role> initialPerms);
            public UserPermissions CreateUserPermissions(string appName, string userName);
            public bool DeleteApplication(Guid applicationId);
            public bool DeleteCategory(int categoryId, bool deleteOnlyIfIsEmpty);
            public bool DeleteCategory(string appName, string roleName, string categoryName, bool deleteOnlyIfIsEmpty);
            public bool DeletePermission(Guid appId, Guid roleId, int categoryId, string permissionName, bool deleteOnlyIfRoleIsEmpty);
            public bool DeleteRole(string appName, string roleName, bool deleteOnlyIfRoleIsEmpty);
            public bool DeleteRole(Guid roleId, bool deleteOnlyIfRoleIsEmpty);
            public bool DeleteUser(string userName);
            public void DisableLogin(string userName);
            public bool EditCategory(int id, string name, string desc, int displayOrder);
            public bool EditPermission(int categoryId, string permissionName, string permissionDesc, string permissionHelpText, int displayOrder, int newCategoryId);
            public bool EditRole(Guid id, string desc);
            public void EnableLogin(string userName);
            public List<Security_User> GetAdministrators();
            public List<Security_User> GetAllUsers();
            public Application GetApplication(Guid applicationId);
            public List<Application> GetApplications();
            public List<Security_User> GetApplicationUsers(Guid applicationId);
            public int GetAvailableDisplayOrder(int categoryId);
            public int GetAvailableDisplayOrder(Guid roleId);
            public List<Role> GetAvailablePermissions(string appName);
            public List<string> GetCategoriesNames(string appName, string roleName);
            public Security_Category GetCategory(int id);
            public Security_Category GetCategory(string appName, string roleName, string categoryName);
            public List<string> GetCategoryPermissionNames(int categoryId);
            public List<string> GetCategoryPermissionNames(string appName, string roleName, string categoryName);
            public User GetCombinedUser(string userName);
            public string GetPasswordQuestion(string userName);
            public Security_Permissions GetPermission(int categoryId, string permissionName);
            public List<Security_Permissions> GetPermissionsForRole(string roleName, string appName);
            public List<Security_Permissions> GetPermissionsForRole(string appName, string roleName, string categoryName);
            public Role GetRole(Guid roleId);
            public Role GetRole(string roleName, string appName);
            public List<Security_Category> GetRoleCategories(string roleName, string appName);
            public List<string> GetRoleNames(string appName);
            public List<string> GetRolePermissionNames(string roleName, string appName);
            public ICollection<Role> GetRoles(Guid applicationId);
            public List<Role> GetRolesForUser(string appName, string userName);
            public List<Security_User> GetUserForAllApps(string userName);
            public Security_User GetUserForApp(string userName, string appName);
            public List<Security_User> GetUserForPermission(int categoryId, string permissionName);
            public MembershipUser MembershipUser(string userName);
            public string ResetPassword(string userName, string passwordAnswer);
            public bool ResetPassword(string userName, string defaultPassword = "", string passWordSalt = "", int passwordFormat = 1);
            public bool RoleExists(string roleName, string appName);
            public bool UnlockUser(string userName);
            public void UpdateEmail(string userName, string email);
            public void UpdateLastLoginDate(string username);
        }
    }
