    public class AuthenticationOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Security = new List<IDictionary<string, IEnumerable<string>>>
            {
                new Dictionary<string, IEnumerable<string>>
                {
                    //Note "OAuth2" casing here must match the definition you use in Swagger UI config
                    ["OAuth2"] = new List<string>{ "user_impersonation" }
                }
            };
        }
    }
