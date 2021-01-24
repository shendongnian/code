    [AttributeUsage(AttributeTargets.Property)]
    public class RequireRoleViewAttribute : Attribute
    {
        public List<String> AllowedRoles { get; set; }
        public RequireRoleViewAttribute(params String[] AllowedRoles) =>
            this.AllowedRoles = AllowedRoles.Select(ar => ar.ToLower()).ToList();
    }
