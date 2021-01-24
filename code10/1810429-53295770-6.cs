    [AttributeUsageAttribute(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class RequireRoleViewAttribute : Attribute
    {
        
        public string Role;
        public RequireRoleViewAttribute(string role){
            this.Role = role;
        }
    }
