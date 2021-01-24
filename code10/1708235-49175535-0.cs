    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomAuthorizeAttribute : Attribute
    {
        public eUserRole CustomRoles { get; set; } = eUserRole.Administrator;
    }
