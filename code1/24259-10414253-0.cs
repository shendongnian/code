    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class AuthorizedGmp : AuthorizeAttribute
    {
        public AuthorizedGmp()
        {
            Roles = Config.GMPUser;
        }
    }
