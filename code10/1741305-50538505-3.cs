    public class RequireAuthAttribute : TypeFilterAttribute
    {
        public RequireAuthAttribute(params Roles[] rolesRequirement) 
            : base(typeof(RequireAuthFilter))
        {
            Arguments = new object[] { rolesRequirement };
        }
        public enum Roles: ushort
        {
            CompanyOnly,
            AuthenticatedCustomer,
            AuthorizedCustomer,
            AuthorizedOwnerManager
        }
    }
