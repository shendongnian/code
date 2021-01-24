    public class AuthenticationOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Security = new List<IDictionary<string, IEnumerable<string>>>
            {
                new Dictionary<string, IEnumerable<string>>
                {
                    ["oauth2"] = new List<string>{ "user_impersonation" }
                }
            };
        }
    }
