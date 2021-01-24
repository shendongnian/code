    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public sealed class CustomAuthorizationAttribute : AuthorizeAttribute
    {
         public Enums.Roles Allowed_Roles { get; set; }
    }
