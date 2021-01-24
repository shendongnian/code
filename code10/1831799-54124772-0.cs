    public class MySecurityTokenValidator : ISecurityTokenValidator
    {
            public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
            {
               //// Perform your custom validation here.
            }
    }
