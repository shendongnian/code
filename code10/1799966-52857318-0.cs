    public class RolesFilterAttribute : Attribute, IFilterFactory
    {
        public string Role { get; set; }       
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new RolesFilterAttributeImplementation(
                serviceProvider.GetRequiredService<ValidateRoleClient>(),
                Role
            );
        }
        private class RolesFilterAttributeImplementation : ActionFilterAttribute
        {
            private readonly ValidateRoleClient validateRoleClient;
            private readonly string role;
            public RolesFilterAttributeImplementation(ValidateRoleClient validateRoleClient, string role)
            {
                this.validateRoleClient = validateRoleClient;
                this.role = role;
            }
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.Request.Cookies["Token"] != null || context.HttpContext.Request.Cookies["RefreshToken"] != null)
                {
                    TokenViewModel tvm = new TokenViewModel
                    {
                        Token = context.HttpContext.Request.Cookies["Token"],
                        RefreshToken = context.HttpContext.Request.Cookies["RefreshToken"]
                    };
                    ValidateRoleViewModel vrvm = new ValidateRoleViewModel
                    {
                        Role = role,
                        Token = tvm
                    };
                    validateRoleClient.ValidateRole(vrvm);
                }
            }
        }
        public bool IsReusable => false;
    }
