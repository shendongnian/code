    public class CodeworksPrincipal<TUserData> : IPrincipal where TUserData : class
    {
        private string name;
        private string[] roles;
        private string allRoles;
        private TUserData userData;
        public CodeworksPrincipal( string name, string[] roles, TUserData userData )
        {
            // init fields, etc.
        }
    }
