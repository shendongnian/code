    public class RoleAttribute : Attribute, IActionConstraint
    {
        public int Order => 0;
        private string[] _roles;
        public RoleAttribute(params string[] roles)
        {
            _roles = roles;
        }
        public bool Accept(ActionConstraintContext context)
        {
            var user = context.RouteContext.HttpContext.User;
            var role = user.FindFirst("role-name").Value;
            return _roles.Contains(role);
        }
    }
