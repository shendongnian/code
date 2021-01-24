    public class RolesFilter : IActionFilter
    {
        private readonly ValidateRoleClient validateRoleClient;
        private readonly string role;
        private readonly string secretKey;
        public RolesFilterAttributeImpl(string role, string secretKey, ValidateRoleClient validateRoleClient)
        {
            this.validateRoleClient = validateRoleClient;
            this.role = role;
            this.secretKey = secretKey;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // …
        }
        public void OnActionExecuting(ActionExecutingContext context)
        { }
    }
